import { createMuiTheme } from '@material-ui/core/styles'

const baseTheme = createMuiTheme()

const theme = createMuiTheme({
  ...baseTheme,
  '@global': {
    body: {
      height: '100vh',
      width: '100vw',
      padding: 0,
      margin: 0,
    },
  },
  type: 'light',
  overrides: {
    MuiTypography: {
      gutterBottom: {
        marginBottom: baseTheme.spacing(1.5),
      },
    },
    MuiLink: {
      underlineHover: {
        color: 'inherit',
        textDecoration: 'none',
        '&:hover': {
          textDecoration: 'none',
        },
      },
    },
  },
  palette: {
    primary: {
      main: '#212121',
      light: '#F5F5F5',
      // dark: '#171717',
      // contrastText: '#ffffff',
    },
    secondary: {
      main: '#CFDDC3',
    },
    error: {
      main: '#C3272B',
      dark: '#881b1e',
      light: '#cf5255',
    },
    background: {
      default: '#fff',
    },
  },
  text: {
    primary: '#000',
    secondary: '#fff',
  },
})

export default theme
