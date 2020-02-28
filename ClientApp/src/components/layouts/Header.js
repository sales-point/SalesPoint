import React from 'react'
import {
  AppBar,
  Toolbar,
  Typography,
  Link,
  Grid,
  Button,
  Paper,
  Tab,
  IconButton,
} from '@material-ui/core'
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart'

import { ReactLink } from '../styled'
import { useStyles } from './useStyles'

const Header = () => {
  const classes = useStyles()

  return (
    <>
      <AppBar position="static" color="primary" className={classes.appbar}>
        <Toolbar className={classes.toolbar}>
          <Grid container justify="space-between">
            <Grid container item xs={6}>
              <Link component={ReactLink} to="/">
                <Typography>Суши-бар в Калуге</Typography>
                <Typography>доступно, вкусно, уютно</Typography>
              </Link>
            </Grid>
            <Grid container item xs={3} spacing={2} justify="flex-end">
              <Grid item>
                <Button variant="outlined" color="secondary">
                  <Typography>Вход</Typography>
                </Button>
              </Grid>
              <Grid item>
                <IconButton>
                  <ShoppingCartIcon fontSize="default" color="secondary" />
                </IconButton>
              </Grid>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>

      <AppBar position="sticky">
        <Paper square={true} className={classes.tabpanel}>
          <Grid container item justify="center">
            <Tab label="Сеты" />
            <Tab label="Роллы" />
            <Tab label="Суши" />
            <Tab label="Напитки" />
          </Grid>
        </Paper>
      </AppBar>
    </>
  )
}

export default Header
