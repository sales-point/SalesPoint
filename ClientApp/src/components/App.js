import React, { Suspense } from 'react'
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom'
import { ThemeProvider } from '@material-ui/styles'
import CssBaseline from '@material-ui/core/CssBaseline'
import { theme } from './styled'

import { Header, Footer } from './layouts'
import Homepage from './Homepage/Homepage'
import Cart from './Cart/Cart'

function App() {
  return (
    <Router>
      <Suspense fallback={null}>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Header />
          <Switch>
            <Route exact path="/" component={Homepage} />
            <Route exact path="/cart" component={Cart} />
            <Route path="*" render={() => <Redirect to="/" />} />
          </Switch>
          <Footer />
        </ThemeProvider>
      </Suspense>
    </Router>
  )
}

export default App
