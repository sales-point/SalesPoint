import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles(theme => ({
  cart: {
    width: 240,
    margin: theme.spacing(1, 1),
    display: 'flex',
    flexDirection: 'column',
  },
  cartItem: {
    margin: theme.spacing(1, 0),
  },
  counter: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'flex-start',
    width: 'fit-content',
    margin: theme.spacing(2, 0),
  },
  counterNumber: {
    backgroundColor: theme.palette.primary.light,
    padding: theme.spacing(0.5, 0),
  },
  removeButton: {
    display: 'flex',
    justifyContent: 'flex-end',
    marginTop: theme.spacing(1),
  },
  orderButton: {
    display: 'flex',
    alignContent: 'stretch',
    margin: theme.spacing(2, 0),
  },
  divider: {
    marginBottom: theme.spacing(1),
  },
}))
