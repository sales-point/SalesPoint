import { ADD_ITEM, REMOVE_ITEM, INCREMENT_ITEM, DECREMENT_ITEM } from '../actionTypes'

const initialState = {
  items: [],
}

const updateCounter = (state, itemToUpdate, addNumber) => {
  const newItems = state.items.map(it =>
    it.item === itemToUpdate ? { ...it, count: it.count + addNumber } : it,
  )
  return {
    ...state,
    items: newItems,
  }
}

export default function(state = initialState, action) {
  switch (action.type) {
    case ADD_ITEM: {
      if (state.items.find(it => it.item === action.payload))
        return updateCounter(state, action.payload, 1)
      else
        return {
          ...state,
          items: [...state.items, { item: action.payload, count: 1 }],
        }
    }
    case REMOVE_ITEM: {
      return {
        ...state,
        items: state.items.filter(it => it.item !== action.payload),
      }
    }
    case INCREMENT_ITEM:
      return updateCounter(state, action.payload, 1)
    case DECREMENT_ITEM:
      return updateCounter(state, action.payload, -1)
    default:
      return state
  }
}
