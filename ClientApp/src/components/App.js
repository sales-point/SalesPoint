import React, { Suspense } from 'react'
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom'
import { Provider } from 'react-redux'
import store from '../redux/store'
import { saveState } from '../redux/localStorage'

import { ThemeProvider } from '@material-ui/styles'
import CssBaseline from '@material-ui/core/CssBaseline'
import { theme } from './styled'
import { Header, Footer } from './layouts'
import Homepage from './Homepage/Homepage'
import { Sets, Rolls, Sushi, Drinks } from './Menu'
import Cart from './Cart/Cart'
import Order from './Order/Order'

store.subscribe(() => {
  saveState(store.getState())
})

function App() {
  return (
    <Provider store={store}>
      <Router>
        <Suspense fallback={null}>
          <ThemeProvider theme={theme}>
            <CssBaseline />
            <Header />
            <Switch>
              <Route exact path="/" component={Homepage} />
              <Route path="/cart" component={Cart} />
              <Route path="/order" component={Order} />
              <Route path="/menu/sets" component={Sets} />
              <Route path="/menu/rolls" component={Rolls} />
              <Route path="/menu/sushi" component={Sushi} />
              <Route path="/menu/drinks" component={Drinks} />
              {/* <Route path="*" render={() => <Redirect to="/" />} /> */}
            </Switch>
            <Footer />
          </ThemeProvider>
        </Suspense>
      </Router>
    </Provider>
  )
}

export default App
