import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import StyledButton from "../extras/StyledButton";
import StyledTextArea from "../extras/StyledTextArea";
import StyledTextfield from "../extras/StyledTextfield";

interface Props {
  createFinebox: (name: string, paymentDescription: string) => void;
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
    alignItems: "center",
    width: "100%",
  },
});

function CreateFineboxForm({ createFinebox }: Props) {
  const [name, setName] = useState<string>();
  const [paymentDescription, setPaymentDescription] = useState<string>("");

  const onPress = () => {
    if (name) {
      createFinebox(name, paymentDescription);
    }
  };
  return (
    <View style={styles.container}>
      <StyledTextfield
        onChange={(text) => setName(text)}
        placeholder="Name"
      ></StyledTextfield>
      <StyledTextArea
        onChange={(text) => setPaymentDescription(text)}
        placeholder="Describe how to pay"
        height={100}
      ></StyledTextArea>
      <StyledButton title="Create finebox" onPress={onPress}></StyledButton>
    </View>
  );
}

export default CreateFineboxForm;
