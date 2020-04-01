import React from 'react'
import { useSelector } from 'react-redux'

import { Grid, Typography } from '@material-ui/core'

const ItemList = () => {
  const selectedItems = useSelector(state => state.cart.items)

  const sum = selectedItems.length
    ? selectedItems.reduce(function(previousValue, currentValue) {
        return {
          count: previousValue.count + currentValue.count,
          totalCost:
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
                {it.count > 1 ? (
                  <Typography gutterBottom>
                    Цена: {it.item.price * it.count} P (в количестве {it.count} по {it.item.price} P
                    за штуку)
                  </Typography>
                ) : (
                  <Typography gutterBottom>Цена: {it.item.price} P</Typography>
                )}
              </Grid>
            ))}
            <Typography gutterBottom>
              <b>Итого к оплате:</b> {sum.totalCost} рублей
            </Typography>
          </>
        )}
      </Grid>
    </>
  )
}

export default ItemList
