import React from 'react'
import { Link as RouterLink } from 'react-router-dom'
import { useSelector, useDispatch } from 'react-redux'
import { incrementItem, decrementItem, removeItem } from '../../redux/actions'
import { Drawer, IconButton, Badge, Grid, Typography, Button, Divider } from '@material-ui/core'
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart'
import ChevronRightIcon from '@material-ui/icons/ChevronRight'
import { useStyles } from './useStyles'

const Cart = () => {
  const selectedItems = useSelector(state => state.cart.items)
  const dispatch = useDispatch()
  const classes = useStyles()

  const [open, setOpen] = React.useState(false)
  const sum = selectedItems.length
    ? selectedItems.reduce(function(previousValue, currentValue) {
        return {
          count: previousValue.count + currentValue.count,
        }
      })
    : 0

  const handleDrawerOpen = () => {
    setOpen(true)
  }

  const handleDrawerClose = () => {
    setOpen(false)
  }

  return (
    <>
      {sum ? (
        <IconButton onClick={handleDrawerOpen}>
          <Badge badgeContent={sum.count} color="secondary">
            <ShoppingCartIcon fontSize="default" />
          </Badge>
        </IconButton>
      ) : (
        <IconButton onClick={handleDrawerOpen}>
          <ShoppingCartIcon fontSize="default" />
        </IconButton>
      )}
      <Drawer variant="persistent" anchor="right" open={open}>
        <div className={classes.drawerHeader}>
          <IconButton onClick={handleDrawerClose}>
            <ChevronRightIcon />
          </IconButton>
        </div>
        <Grid container className={classes.cart}>
          {selectedItems.length == 0 ? (
            <Typography variant="h6" align="center">
              Ваша корзина пуста
            </Typography>
          ) : (
            <>
              {selectedItems.map((it, index) => (
                <Grid item key={it.item.id} className={classes.cartItem}>
                  <Divider className={classes.divider} />
                  <Typography gutterBottom>
                    {index + 1}. {it.item.title}
                  </Typography>
                  <Grid container item className={classes.counter}>
                    <Grid item>
                      <Button
                        size="small"
                        variant="contained"
                        color="secondary"
                        onClick={() => dispatch(incrementItem(it.item))}
                      >
                        +
                      </Button>
                    </Grid>
                    <Grid item className={classes.counterNumber}>
                      <Typography align="center">{it.count}</Typography>
                    </Grid>
                    {it.count === 1 ? (
                      <></>
                    ) : (
                      <Grid item>
                        <Button
                          size="small"
                          variant="contained"
                          color="secondary"
                          onClick={() => dispatch(decrementItem(it.item))}
                        >
                          -
                        </Button>
                      </Grid>
                    )}
                  </Grid>
                  {it.count > 1 ? (
                    <Typography gutterBottom>
                      Цена: {it.item.price * it.count} P ({it.item.price} P за штуку)
                    </Typography>
                  ) : (
                    <Typography gutterBottom>Цена: {it.item.price} P</Typography>
                  )}
                  <Grid item className={classes.removeButton}>
                    <Button
                      variant="outlined"
                      color="primary"
                      onClick={() => dispatch(removeItem(it.item))}
                    >
                      Убрать
                    </Button>
                  </Grid>
                </Grid>
              ))}
              <Button
                variant="contained"
                color="secondary"
                component={RouterLink}
                to="/order"
                onClick={handleDrawerClose}
                className={classes.orderButton}
              >
                Оформить заказ
              </Button>
            </>
          )}
        </Grid>
      </Drawer>
    </>
  )
}

export default Cart
