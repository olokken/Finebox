import React from "react";
import { StyleSheet } from "react-native";
import { Input } from "react-native-elements";

interface Props {
  onChange: (text: string) => void;
  placeholder: string;
  isPassword?: boolean;
}

const styles = StyleSheet.create({
  input: {
    marginTop: 5,
    color: "#EEA47FFF",
  },
});

function StyledTextfield({ onChange, placeholder, isPassword }: Props) {
  return (
    <Input
      style={styles.input}
      onChangeText={onChange}
      placeholder={placeholder}
      secureTextEntry={isPassword ? isPassword : false}
    />
  );
}

export default StyledTextfield;
