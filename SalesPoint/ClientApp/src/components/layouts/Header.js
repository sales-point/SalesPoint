import React from 'react'
import { AppBar, Toolbar, Typography, Link } from '@material-ui/core'

import { ReactLink } from '../styled'

const Header = () => {
  return (
      <AppBar position="static" color="primary">
        <Toolbar>
          <Typography variant="h6" style={{ margin: 'auto' }}>
            <Link component={ReactLink} to="/">
              Sushi
            </Link>
          </Typography>
        </Toolbar>
      </AppBar>
  )
}

export default Header
