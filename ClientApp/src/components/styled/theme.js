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
      main: '#FAA945', // Цвет кукурузы (#CA6924 - цвет янтаря)
      light: '#fbba6a',
      dark: '#af7630',
    },
    secondary: {
      main: '#7A942E', // Жёлтый [как] молодые ростки
      light: '#94a957',
      contrastText: '#556720',
    },
    error: {
      main: '#C3272B', // чисто-алый
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
