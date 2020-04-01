import { makeStyles } from '@material-ui/styles'
import BackgroundMenuSections from '../../images/bg_menu_sections.jpg'

export const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4, 4),
  },
  briefInfoSection: {
    display: 'flex',
    flexDirection: 'column',
    alignContent: 'center',
    backgroundColor: theme.palette.secondary.main,
    width: 'inherit',
    padding: theme.spacing(8, 4),
  },
  briefInfoPart: {
    padding: theme.spacing(0, 0, 4, 0),
    maxWidth: '1500px',
  },
  menuSection: {
    backgroundImage: `url(${BackgroundMenuSections})`,
    padding: theme.spacing(10, 4),
  },
}))
