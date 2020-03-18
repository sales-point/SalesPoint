import React from 'react'
import { useLocation, withRouter, Link as RouterLink } from 'react-router-dom'
import { AppBar, Toolbar, Typography, Link, Grid, Button, Tabs, Tab } from '@material-ui/core'

import { ReactLink } from '../styled'
import { useStyles } from './useStyles'
import Cart from '../Cart/Cart'

const Header = ({ history }) => {
  const allTabs = ['/', '/menu/sets', '/menu/rolls', '/menu/sushi', '/menu/drinks']
  const [value, setValue] = React.useState(useLocation().pathname)
  history.listen(location => {
    setValue(location.pathname)
  })

  const classes = useStyles()

  const handleChange = (event, newValue) => {
    setValue(newValue)
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
              <Button variant="outlined" className={classes.loginButton}>
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
          <Grid item>{value === '/order' ? null : <Cart />}</Grid>
        </Grid>
      </AppBar>
    </>
  )
}

export default withRouter(Header)
