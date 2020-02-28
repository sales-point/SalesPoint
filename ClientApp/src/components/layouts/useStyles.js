import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles(theme => ({
  appbar: {
    padding: theme.spacing(1, 0),
  },
  toolbar: {
    display: 'flex',
    flexDirection: 'column',
  },
  tabpanel: {
    flexGrow: 1,
    backgroundColor: '#F5F5F5',
  },
  footer: {
    backgroundColor: '#F5F5F5',
    padding: theme.spacing(3, 0),
  },
}))
