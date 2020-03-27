import { ADD_ITEM, REMOVE_ITEM, INCREMENT_ITEM, DECREMENT_ITEM } from './actionTypes'

export const addItem = content => ({
  type: ADD_ITEM,
  payload: content,
})

export const incrementItem = content => ({
  type: INCREMENT_ITEM,
  payload: content,
})

export const decrementItem = content => ({
  type: DECREMENT_ITEM,
  payload: content,
})

export const removeItem = content => ({
  type: REMOVE_ITEM,
  payload: content,
})
