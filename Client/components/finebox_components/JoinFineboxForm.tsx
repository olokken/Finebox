import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import StyledButton from "../extras/StyledButton";
import StyledTextfield from "../extras/StyledTextfield";

interface Props {
  joinFinebox: (code: string) => void;
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
    alignItems: "center",
    width: "100%",
  },
});

function JoinFineboxForm({ joinFinebox }: Props) {
  const [code, setCode] = useState<string>();

  const onPress = () => {
    if (code) {
      joinFinebox(code);
    }
  };

  return (
    <View style={styles.container}>
      <StyledTextfield
        onChange={(text) => setCode(text)}
        placeholder="Code"
      ></StyledTextfield>
      <StyledButton title="Join finebox" onPress={onPress}></StyledButton>
    </View>
  );
}

export default JoinFineboxForm;
