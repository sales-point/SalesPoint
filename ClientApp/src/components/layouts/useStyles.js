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
    padding: theme.spacing(0, 1),
    backgroundColor: '#F5F5F5',
    color: '#000',
  },
  footer: {
    backgroundColor: '#F5F5F5',
    padding: theme.spacing(3, 0),
  },
  drawerHeader: {
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
    justifyContent: 'flex-start',
  },
}))
