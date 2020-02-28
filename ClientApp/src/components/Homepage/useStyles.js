import { makeStyles } from '@material-ui/styles'
import BackgroundMenuSections from '../../images/bg_menu_sections.jpg'

export const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(4, 4),
  },
  briefInfoSection: {
    backgroundColor: '#CFDDC3',
    width: 'inherit',
    padding: theme.spacing(8, 10),
  },
  briefInfoPart: {
    padding: theme.spacing(0, 0, 4, 0),
  },
  menuSection: {
    backgroundImage: `url(${BackgroundMenuSections})`,
    padding: theme.spacing(10, 4),
  },
}))
