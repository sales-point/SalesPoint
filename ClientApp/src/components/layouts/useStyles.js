import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles(theme => ({
  appbar: {
    padding: theme.spacing(1, 0),
  },
  toolbar: {
    display: 'flex',
    flexDirection: 'column',
  },
  loginButton: {
    color: theme.palette.background.default,
    borderColor: theme.palette.background.default,
    '&:hover': {
      color: theme.palette.primary.light,
      borderColor: theme.palette.primary.light,
    },
  },
  tabpanel: {
    padding: theme.spacing(0, 1),
    backgroundColor: theme.palette.primary.light,
    color: theme.palette.text.primary,
  },
  footer: {
    backgroundColor: theme.palette.primary.light,
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
