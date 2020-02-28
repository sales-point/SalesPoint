import React from 'react'
import { Typography, Link, Container } from '@material-ui/core'

import { ReactLink } from '../styled'

const Cart = () => {
  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        Cart page
      </Typography>
      <Link component={ReactLink} to="/">
        Get back
      </Link>
    </Container>
  )
}

export default Cart
