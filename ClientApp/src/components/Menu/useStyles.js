import { makeStyles } from '@material-ui/styles'

export const useStyles = makeStyles(theme => ({
  itemsSection: {
    margin: theme.spacing(5, 0),
  },
  previewCard: {
    maxWidth: 600,
    display: 'flex',
    marginTop: 5,
    marginBottom: 10,
  },
  cardImage: {
    maxWidth: 200,
    minWidth: 200,
    margin: 5,
    flex: 1,
    // align: 'center',
  },
  cardContent: {
    width: '100%',
    minHeight: 250,
    marginTop: 5,
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'space-between',
  },
  cardActions: {
    display: 'flex',
    justifyContent: 'space-between',
    backgroundColor: theme.palette.primary.light,
    paddingLeft: theme.spacing(1),
  },
}))
