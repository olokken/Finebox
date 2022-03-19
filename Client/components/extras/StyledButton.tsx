import React from "react";
import { Button } from "react-native-elements";

interface Props {
  onPress: () => void;
  title: string;
}

function StyledButton({ onPress, title }: Props) {
  return (
    <Button
      buttonStyle={{
        backgroundColor: "#EEA47FFF",
        borderRadius: 5,
      }}
      containerStyle={{
        marginBottom: 10,
        width: 300,
      }}
      title={title}
      onPress={onPress}
    ></Button>
  );
}

export default StyledButton;
