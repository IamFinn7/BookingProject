import React from "react";
import { TextField } from "@mui/material";

const InputField = ({ label, type, value, onChange }) => {
  return (
    <TextField
      fullWidth
      label={label}
      type={type}
      margin="normal"
      value={value}
      onChange={onChange}
    />
  );
};

export default InputField;
