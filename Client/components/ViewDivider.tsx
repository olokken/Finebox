import React, { useEffect, useState } from "react";
import { View } from "react-native";
import { Button, Divider } from "react-native-elements";

interface Props {
  returnView: (createView: boolean) => void;
}

function ViewDivider({ returnView }: Props) {
  const [createView, changeView] = useState<boolean>(true);

  const onClickJoin = () => {
    changeView(false);
  };

  const onClickCreate = () => {
    changeView(true);
  };

  useEffect(() => {
    returnView(createView);
  }, [createView]);

  return (
    <View style={{ flexDirection: "row" }}>
      <Button
        onPress={onClickCreate}
        title={"Create"}
        buttonStyle={
          createView
            ? {
                backgroundColor: "#EEA47FFF",
              }
            : { backgroundColor: "#234E70" }
        }
        containerStyle={{
          marginBottom: 10,
          width: "50%",
        }}
      />
      <Divider orientation="vertical" />
      <Button
        onPress={onClickJoin}
        title={"Join"}
        buttonStyle={
          !createView
            ? {
                backgroundColor: "#EEA47FFF",
              }
            : { backgroundColor: "#234E70" }
        }
        containerStyle={{
          marginBottom: 10,
          width: "50%",
        }}
      />
    </View>
  );
}

export default ViewDivider;
