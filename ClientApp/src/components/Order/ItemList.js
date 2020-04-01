import React from 'react'
import { useSelector } from 'react-redux'

import { Grid, Typography, ButtonGroup, Button } from '@material-ui/core'

const ItemList = () => {
  const selectedItems = useSelector(state => state.cart.items)

  const sum =
    selectedItems.length > 0
      ? selectedItems.reduce(function(previousValue, currentValue) {
          return {
            count: previousValue.count + currentValue.count,
            cost:
              previousValue.count * previousValue.item.price +
              currentValue.count * currentValue.item.price,
          }
        })
      : 0

  return (
    <>
      <Typography variant="h5" gutterBottom>
        Товары в вашей корзине
      </Typography>
      <Grid container direction="column">
        {selectedItems.length == 0 ? (
          <Typography variant="h6" align="center">
            Ваша корзина пуста
          </Typography>
        ) : (
          <>
            {selectedItems.map((it, index) => (
              <Grid item key={it.item.id}>
                <Typography gutterBottom>
                  {index + 1}. {it.item.title}
                </Typography>
                <Grid item container direction="row" spacing={2}>
                  <Grid item>
                    {it.count > 1 ? (
                      <Typography gutterBottom>
                        Цена: {it.item.price * it.count} P (в количестве {it.count} по{' '}
                        {it.item.price} P за штуку)
                      </Typography>
                    ) : (
                      <Typography gutterBottom>Цена: {it.item.price} P</Typography>
                    )}
                  </Grid>
                  <Grid item>
                    <ButtonGroup color="secondary">
                      <Button size="small" variant="contained">
                        +
                      </Button>
                      {it.count > 1 ? (
                        <Button size="small" variant="contained">
                          -
                        </Button>
                      ) : (
                        <></>
                      )}
                      <Button size="small" variant="contained">
                        Убрать товар
                      </Button>
                    </ButtonGroup>
                  </Grid>
                </Grid>
              </Grid>
            ))}
            <Typography gutterBottom>
              <b>Итого к оплате:</b>{' '}
              {sum.cost ? sum.cost : selectedItems[0].item.price * selectedItems[0].count} рублей
            </Typography>
          </>
        )}
      </Grid>
    </>
  )
}

export default ItemList
