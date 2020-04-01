import { createStore, applyMiddleware, compose } from 'redux'
import rootReducer from './reducers'
import { loadState } from './localStorage'
import thunk from 'redux-thunk'

const middleware = [thunk]
const persistedState = loadState()
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose

export default createStore(
  rootReducer,
  persistedState,
  composeEnhancers(applyMiddleware(...middleware)),
)
