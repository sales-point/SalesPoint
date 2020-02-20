import React from 'react'
import { Typography, Link, Container } from '@material-ui/core'

import { ReactLink } from './styled'

const Homepage = () => {
  return (
    <Container>
    <Typography variant="h4" gutterBottom>
      Homepage
    </Typography>
    <Link component={ReactLink} to="/cart">
      Test Route
    </Link>
    </Container>
  )
}

export default Homepage
