import React from 'react'
import { Form, Field } from 'react-final-form'
import MaskedInput from 'react-text-mask'

import { Typography, Button, MenuItem } from '@material-ui/core'
import { TextField, Select } from '../styled'

const NumberFormatCustom = props => {
  const { inputRef, ...other } = props

  return (
    <MaskedInput
      {...other}
      ref={ref => {
        inputRef(ref ? ref.inputElement : null)
      }}
      mask={[
        '+',
        '7',
        ' ',
        '(',
        /\d/,
        /\d/,
        /\d/,
        ')',
        ' ',
        /\d/,
        /\d/,
        /\d/,
        '-',
        /\d/,
        /\d/,
        '-',
        /\d/,
        /\d/,
      ]}
      placeholderChar={'\u2000'}
      showMask
      onBlur={() => {}}
      onChange={() => {}}
    />
  )
}

const OrderForm = () => {
  const paymentOptions = ['Оплата наличными', 'Оплата картой']
  const [values, setValues] = React.useState({
    numberMask: '(1  )    -    ',
  })
  const handleChange = name => event => {
    setValues({
      ...values,
      [name]: event.target.value,
    })
  }

  const required = value => (value ? undefined : 'Это обязательное поле')

  const onSubmit = values => {
    console.log('submit btn clicked')
    console.log(values)
  }

  return (
    <>
      <Typography variant="h5" gutterBottom>
        Заполните форму для связи
      </Typography>
      <Form
        onSubmit={onSubmit}
        initialValues={{
          payment: paymentOptions[0],
        }}
        render={({ handleSubmit, form, submitting, pristine, values }) => (
          <form onSubmit={handleSubmit}>
            <div>
              <Field margin="dense" component={Select} name="payment" label="Способ оплаты">
                {paymentOptions.map((option, index) => (
                  <MenuItem key={index} value={option}>
                    {option}
                  </MenuItem>
                ))}
              </Field>
            </div>
            <div>
              <Field
                margin="dense"
                name="firstname"
                component={TextField}
                validate={required}
                type="text"
                label="Ваше имя"
              />
            </div>
            <div>
              <Field
                margin="dense"
                name="phoneNumber"
                component={TextField}
                validate={required}
                type="text"
                label="Номер телефона"
                onChange={handleChange('numberMask')}
                InputProps={{
                  inputComponent: NumberFormatCustom,
                }}
              />
            </div>
            <div>
              <Field
                margin="dense"
                name="address"
                component={TextField}
                validate={required}
                type="text"
                label="Улица, дом, квартира"
              />
            </div>
            <div>
              <Button
                variant="outlined"
                color="primary"
                type="submit"
                disabled={submitting || pristine}
                style={{ marginTop: 10 }}
              >
                Оформить заказ
              </Button>
            </div>
          </form>
        )}
      />
    </>
  )
}

export default OrderForm
