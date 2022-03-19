import React from "react";
import { Overlay, Text } from "react-native-elements";
import StyledButton from "./StyledButton";
import { StyleSheet, View } from "react-native";

interface Props {
  isVisible: boolean;
  message: string;
  close: () => void;
}

const styles = StyleSheet.create({
  text: {
    textAlign: "center",
    margin: 10,
    marginBottom: 25,
    fontSize: 25,
  },
  view: {
    alignItems: "center",
    padding: 3,
  },
});

function StyledPopup({ isVisible, message, close }: Props) {
  return (
    <Overlay isVisible={isVisible}>
      <View style={styles.view}>
        <Text style={styles.text}>{message}</Text>
        <StyledButton title="Close" onPress={close}></StyledButton>
      </View>
    </Overlay>
  );
}

export default StyledPopup;
