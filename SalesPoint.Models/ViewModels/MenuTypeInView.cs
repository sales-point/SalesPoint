using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class MenuTypeInView
    {
        [Required(ErrorMessage ="Не указана страница для отображения")]
        [Range(1, int.MaxValue, ErrorMessage = "Номер страницы должен быть больше 0")]
        public int? Page { get; set; }

        [Required(ErrorMessage = "Не указано количество элементов на странице для отображения")]
        [Range(1, 100, ErrorMessage = "Количество элементов на странице должно быть больше 0 и меньше 100")]
        public int? CountPerPage { get; set; }

        public string Name { get; set; }
    }
}
