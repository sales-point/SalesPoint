import React from 'react'
import { Container, Typography, Link } from '@material-ui/core'
import { useStyles } from './useStyles'

const Footer = () => {
  const classes = useStyles()
  return (
    <footer className={classes.footer}>
      <Container maxWidth="lg">
        <Typography
          gutterBottom
          variant="subtitle1"
          align="center"
          color="textSecondary"
          component="p"
        >
          Суши-бар в Калуге (учебный проект)
        </Typography>
        <Typography variant="subtitle1" align="center" color="textSecondary" component="p">
          © 2020{' '}
          <Link href="https://github.com/sales-point/SalesPoint" underline="none" color="inherit">
            Sales-Point
          </Link>
        </Typography>
      </Container>
    </footer>
  )
}
export default Footer
