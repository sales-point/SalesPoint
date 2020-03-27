import React from 'react'
import { Link as RouterLink } from 'react-router-dom'
import {
  Typography,
  Grid,
  Link,
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
} from '@material-ui/core'
import { useStyles } from './useStyles'

import SetMenuIcon from '../../images/set_menu_icon.png'
import RollsMenuIcon from '../../images/rolls_menu_icon.png'
import SushiMenuIcon from '../../images/sushi_menu_icon.png'
import DrinksMenuIcon from '../../images/drinks_menu_icon.png'

import NewsCarousel from './NewsCarousel'

const Homepage = () => {
  const classes = useStyles()

  let menuSections = [
    {
      title: 'Сеты',
      href: 'menu/sets',
      description: `Виртуозно составленные нашими поварами композиции из различных видов суши
    смогут удовлетворить потребности даже самого искушенного клиента. На выбор
    предоставляются сезонные сеты, различные сеты из горячих, острых роллов и
    комбинирующие сеты.`,
      image: SetMenuIcon,
    },
    {
      title: 'Роллы',
      href: 'menu/rolls',
      description: `Роллы могут быть разнообразными по своему компонентному составу и особенностям
    приготовления: с овощами, фруктами, быть сладкими, солеными, с кунжутом и без,
    иметь нори как сверху, так и внутри, быть горячими или холодными, могут
    подаваться в жаренном виде.`,
      image: RollsMenuIcon,
    },
    {
      title: 'Суши',
      href: 'menu/sushi',
      description: `Суши подаются всегда только холодными, все компоненты имеют примерно
    одинаковую форму, аккуратно укладываются друг на друга, дополнительные
    ингредиенты - это лишь небольшое дополнение к тандему риса и рыбки
    (морепродуктов).`,
      image: SushiMenuIcon,
    },
    {
      title: 'Напитки',
      href: 'menu/drinks',
      description: `Японские напитки наравне с едой отличаются вкусом и подачей, удивляя туристов
    и открывая новые вкусовые ощущения. В этом разделе меню вы можете заказать
    традиционные японские чаи, такие как сенча, гёкуро и матча, либо выбрать более
    привычные обычные напитки.`,
      image: DrinksMenuIcon,
    },
  ]

  return (
    <Grid container>
      {/* Greeting and carousel */}
      <Grid container item>
        <NewsCarousel />
      </Grid>
      {/* Menu section */}
      <Grid container item xs={12} className={classes.menuSection}>
        <Grid container item spacing={6} justify="center">
          {menuSections.map(item => (
            <Grid item key={item.title}>
              <Link underline="none" component={RouterLink} to={item.href}>
                <Card style={{ maxWidth: 345 }}>
                  <CardActionArea>
                    <CardMedia style={{ height: 140 }} image={item.image} title={item.title} />
                    <CardContent>
                      <Typography gutterBottom variant="h5" component="h2">
                        {item.title}
                      </Typography>
                      <Typography
                        variant="body2"
                        color="textSecondary"
                        component="p"
                        style={{ minHeight: 140 }}
                      >
                        {item.description}
                      </Typography>
                    </CardContent>
                  </CardActionArea>
                </Card>
              </Link>
            </Grid>
          ))}
        </Grid>
      </Grid>
      {/* Brief introduction */}
      <Grid container item className={classes.briefInfoSection}>
        <Grid item className={classes.briefInfoPart}>
          <Typography variant="h4" gutterBottom>
            Почему мы?
          </Typography>
          <Typography>
            <i>Японская кухня </i> — это национальная кухня японцев, включающая в себя в основном
            натуральные продукты с минимальным временем их кулинарной обработки.
          </Typography>
          <Typography>
            <i>Су́ши (су́си)</i> — блюдо традиционной японской кухни, приготовленное из риса с
            уксусной приправой и различных морепродуктов, а также других ингредиентов.
          </Typography>
          <Typography>
            Суши имеют множество подвидов, один из них — роллы. Они имеют более сложную
            многокомпонентную рецептуру, при приготовлении используется особый кулинарный инвентарь
            — бамбуковая циновка. С начала 1980-х годов суши получило широкую популярность в мире.
          </Typography>
          <Typography>
            <b>Наша миссия</b> — бережливо перенимая лучшие практики японской традиционной кухни
            готовить для наших гостей суши.
          </Typography>
          <Typography>
            <b>Наши повара</b> — специалисты в сфере японской кухни и смогут приготовить ваше
            любимое блюдо на высшем уровне!
          </Typography>
        </Grid>
        <Grid item className={classes.briefInfoPart}>
          <Typography variant="h4" gutterBottom>
            Как заказать роллы?
          </Typography>
          <Typography>
            Мы работаем круглосуточно ежедневно без праздников и выходных. Вы всегда сможете вкусно
            покушать сами и покормить ваших близких в любое удобное для вас время.
          </Typography>
          <Typography>
            Чтобы сделать заказ роллов из ресторана, совсем не обязательно тратить драгоценное время
            на поездку к нам. Все гораздо проще: для вашего комфорта мы работаем в режиме онлайн.
            Именно поэтому сразу же на нашем официальном ресурсе каждый клиент может просмотреть наш
            виртуальный каталог еды, пополнить выбранными товарами корзину и оформить заказ с
            указанием данных для обратной связи для наших менеджеров
          </Typography>
        </Grid>
      </Grid>
    </Grid>
  )
}

export default Homepage
