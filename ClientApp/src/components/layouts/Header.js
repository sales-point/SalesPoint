import React from 'react'
import { useLocation, withRouter, Link as RouterLink } from 'react-router-dom'
import {
  AppBar,
  Toolbar,
  Typography,
  Link,
  Grid,
  Button,
  Tabs,
  Tab,
  IconButton,
  Drawer,
} from '@material-ui/core'
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart'
import ChevronRightIcon from '@material-ui/icons/ChevronRight'

import { ReactLink } from '../styled'
import { useStyles } from './useStyles'
import Cart from '../Cart/Cart'

const Header = ({ history }) => {
  const allTabs = ['/', '/menu/sets', '/menu/rolls', '/menu/sushi', '/menu/drinks']
  const [value, setValue] = React.useState(useLocation().pathname)
  history.listen(location => {
    setValue(location.pathname)
  })

  const [open, setOpen] = React.useState(false)

  const classes = useStyles()

  const handleChange = (event, newValue) => {
    setValue(newValue)
  }

  const handleDrawerOpen = () => {
    setOpen(true)
  }

  const handleDrawerClose = () => {
    setOpen(false)
  }

  return (
    <>
      <AppBar position="static" color="primary" className={classes.appbar}>
        <Toolbar className={classes.toolbar}>
          <Grid container justify="space-between">
            <Grid item>
              <Link component={ReactLink} to="/">
                <Typography>Суши-бар в Калуге</Typography>
                <Typography>доступно, вкусно, уютно</Typography>
              </Link>
            </Grid>
            <Grid item>
              <Button variant="outlined" color="secondary">
                <Typography>Вход</Typography>
              </Button>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>

      <AppBar position="sticky">
        <Grid container item justify="space-between" className={classes.tabpanel}>
          <Grid item></Grid>
          <Grid item>
            <Tabs value={value} indicatorColor="primary" onChange={handleChange}>
              <Tab value={`${allTabs[0]}`} disabled style={{ minWidth: 0, padding: 0 }} />
              <Tab
                label="Сеты"
                value={`${allTabs[1]}`}
                component={RouterLink}
                to={`${allTabs[1]}`}
              />
              <Tab
                label="Роллы"
                value={`${allTabs[2]}`}
                component={RouterLink}
                to={`${allTabs[2]}`}
              />
              <Tab
                label="Суши"
                value={`${allTabs[3]}`}
                component={RouterLink}
                to={`${allTabs[3]}`}
              />
              <Tab
                label="Напитки"
                value={`${allTabs[4]}`}
                component={RouterLink}
                to={`${allTabs[4]}`}
              />
            </Tabs>
          </Grid>
          <Grid item>
            <IconButton onClick={handleDrawerOpen}>
              <ShoppingCartIcon fontSize="default" />
            </IconButton>
          </Grid>
        </Grid>
      </AppBar>

      <Drawer variant="persistent" anchor="right" open={open}>
        <div className={classes.drawerHeader}>
          <IconButton onClick={handleDrawerClose}>
            <ChevronRightIcon />
          </IconButton>
        </div>
        <Grid container style={{ width: 240 }}>
          <Cart />
        </Grid>
      </Drawer>
    </>
  )
}

export default withRouter(Header)
