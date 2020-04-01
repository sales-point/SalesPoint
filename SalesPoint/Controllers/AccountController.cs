using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesPoint.Data;
using SalesPoint.Filters;
using SalesPoint.Models.ViewModels;
using SalesPoint.Repositories.IRepositories;

namespace SalesPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ApiController]
    [ActionFilterValidation]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly DataContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        [HttpGet]
        public JsonResult Error()
        {
            
            return new JsonResult(new { exception = true, pathString = true});
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserView user)
        {
            try
            {
                _context.Database.BeginTransaction();

                var applicationUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Email,
                    FullName = user.FullName
                };

                var regResult = await _userManager.CreateAsync(applicationUser, user.Password);

                if (regResult.Succeeded)
                {
                    var registredUser = await _userManager.FindByEmailAsync(user.Email);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(registredUser);
                    var roleResult = await _userManager.AddToRoleAsync(registredUser, "Customer");
                    _context.Database.CommitTransaction();
                    return new JsonResult(new { success = true });
                }
                else
                {
                    _context.Database.RollbackTransaction();
                    throw new Exception("Ошибка при регистрации пользователя");
                }
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async /*Task<RedirectResult> */Task Login([FromBody] AuthenticationUserView user, string returnUrl)
        {
            var applicationUser = await _userManager.FindByEmailAsync(user.Email);
            if (applicationUser==null)
                throw new Exception("Пользователь не найден или неверно указаны почта или пароль");
            var r = await _signInManager.PasswordSignInAsync(applicationUser, user.Password, user.RememberMe, false);
            if (!r.Succeeded)
                throw new Exception("Пользователь не найден или неверно указаны почта или пароль");
            //return Redirect(string.IsNullOrEmpty(returnUrl) ? "/Home/" : returnUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<JsonResult> AddToRole(string roleName, Guid? userGuid )
        {
            try
            {
                if (userGuid == null)
                    throw new Exception("Не найден пользователь");
                var user = await _userManager.FindByIdAsync(userGuid?.ToString());
                if (user == null)
                    throw new Exception("Не найден пользователь");
                var res = await _userManager.AddToRoleAsync(user, roleName);
                if (!res.Succeeded)
                    throw new Exception($"Не удалось добавить пользователю роль: {res.Errors.ToList()}");
                return new JsonResult(new { success = true});
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = true, msg = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles ="Administrator")]
        public async Task<JsonResult> GetRoles(RoleInView role)
        {
            string name = role.Role.Name ?? "";
            var rolesQuery = _roleManager.Roles.Where(r => r.NormalizedName.Contains(name.ToUpper()));
            var total = rolesQuery.Count();
            var roles = rolesQuery.Skip((role.PageModel.Page-1)*role.PageModel.CountPerPage)
                .Take(role.PageModel.CountPerPage).ToList()
                .Select(r=> new RoleOutView
                {
                    RoleId = r.Id,
                    RoleName = r.Name
                }).ToList();

            return new JsonResult(new { success = true, total, roles});
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<JsonResult> GetUsers(PagedView view)
        {
            var query = _userManager.Users;
            var total = query.Count();
            var result = query.Skip((view.Page - 1) * view.CountPerPage).Take(view.CountPerPage)
                .Select(u => new 
                { 
                    FullName = u.FullName,
                    UserName = u.UserName,
                    Email = u.Email,
                    Id = u.Id
                });

            return new JsonResult(new { success = true, total, result });
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetUserRoles(UserInfoInView userFilter)
        {
            ApplicationUser user = null;
            if (userFilter.User.UserId.HasValue)
                user = await _userManager.FindByIdAsync(userFilter.User.UserId.ToString());
            else
            if (userFilter.User.Email != null)
                user = await _userManager.FindByEmailAsync(userFilter.User.Email);
            else
                if (userFilter.User.Name != null)
                    user = await _userManager.FindByNameAsync(userFilter.User.Name);
            if (user == null)
                throw new Exception("Пользователь не найден");
            var page = userFilter.PageModel.Page;
            var countPerPage = userFilter.PageModel.CountPerPage;
            var roleQuery = (await _userManager.GetRolesAsync(user));
            var roles = roleQuery.Skip((page-1) * countPerPage).Take(countPerPage).ToList().Select(r => new RoleOutView
            {
                RoleName = r
            });
            var total = roleQuery.Count;
            return new JsonResult(new { success = true, total, roles });
        }
    }
}