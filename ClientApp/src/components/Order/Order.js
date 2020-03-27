import React from 'react'
import { Paper, Grid, Typography, Button, Stepper, Step, StepLabel } from '@material-ui/core'
import { useStyles } from './useStyles'
import ItemList from './ItemList'
import OrderForm from './OrderForm'

const Order = () => {
  const classes = useStyles()

  return (
    <Paper variant="outlined" elevation={3} className={classes.root}>
      <ItemList />
      <OrderForm />
    </Paper>
  )
}

export default Order
