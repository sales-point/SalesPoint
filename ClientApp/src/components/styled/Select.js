import React from 'react'
import FormControl from '@material-ui/core/FormControl'
import InputLabel from '@material-ui/core/InputLabel'
import Select from '@material-ui/core/Select'
import FormHelperText from '@material-ui/core/FormHelperText'

export default ({
  input: { name, value, onChange, ...restInput },
  meta,
  label,
  formControlProps,
  ...rest
}) => {
  const showError = ((meta.submitError && !meta.dirtySinceLastSubmit) || meta.error) && meta.touched

  return (
    <FormControl {...formControlProps} error={showError} style={{ minWidth: 195 }}>
      <InputLabel htmlFor={name}>{label}</InputLabel>

      <Select {...rest} name={name} onChange={onChange} inputProps={restInput} value={value} />

      {showError && <FormHelperText>{meta.error || meta.submitError}</FormHelperText>}
    </FormControl>
  )
}
