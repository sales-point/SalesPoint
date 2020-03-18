import React from 'react'
import { useDispatch } from 'react-redux'
import { ADD_ITEM } from '../../redux/actionTypes'
import {
  Container,
  Box,
  Grid,
  Typography,
  Button,
  Card,
  CardMedia,
  CardContent,
  Link,
} from '@material-ui/core'
import { useStyles } from './useStyles'

import data from './menuItemsTest'

const Rolls = () => {
  const dispatch = useDispatch()
  const classes = useStyles()

  return (
    <Container>
      <Box my={3}>
        <Typography variant="h4" gutterBottom align="center">
          Роллы
        </Typography>
        <Grid container spacing={3}>
          {data.map(item => (
            <Grid item md={6} key={item.id}>
              <Card className={classes.previewCard}>
                <CardMedia image={item.image} title={item.title} className={classes.cardImage} />
                <CardContent className={classes.cardContent}>
                  <div>
                    <Link href="">
                      <Typography variant="h5" gutterBottom>
                        {item.title}
                      </Typography>
                    </Link>
                    <Typography variant="subtitle2" paragraph>
                      <i>{item.weight} грамм</i>
                    </Typography>
                    <Typography variant="subtitle1" paragraph>
                      {item.description}
                    </Typography>
                  </div>
                  <div className={classes.cardActions}>
                    <Typography variant="h6">{item.price} Р</Typography>
                    <Button
                      disableElevation
                      color="secondary"
                      variant="contained"
                      onClick={() => dispatch({ type: ADD_ITEM, payload: item })}
                    >
                      В корзину
                    </Button>
                  </div>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Box>
    </Container>
  )
}

export default Rolls
