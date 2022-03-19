import React from "react";
import { StyleSheet } from "react-native";
import { Input } from "react-native-elements";

interface Props {
  onChange: (text: string) => void;
  placeholder: string;
  height: number;
}

function StyledTextArea({ onChange, placeholder, height }: Props) {
  const styles = StyleSheet.create({
    input: {
      marginTop: 5,
      color: "#EEA47FFF",
      height: height,
    },
  });

  return (
    <Input
      multiline={true}
      style={styles.input}
      onChangeText={onChange}
      placeholder={placeholder}
    />
  );
}

export default StyledTextArea;
