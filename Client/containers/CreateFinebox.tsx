import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { post } from "../ajax";
import StyledPopup from "../components/extras/StyledPopup";
import CreateFineboxForm from "../components/finebox_components/CreateFineboxForm";
import JoinFineboxForm from "../components/finebox_components/JoinFineboxForm";
import ViewDivider from "../components/ViewDivider";
import { useAuth } from "../contexts/AuthContext";

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
    alignItems: "center",
  },
});

function CreateFinebox() {
  const [createView, changeView] = useState<boolean>(true);
  const [message, setMessage] = useState<string>("");
  const [showPopup, setShowPopup] = useState<boolean>(false);
  const { userId } = useAuth();

  const joinFinebox = (code: string) => {
    post("/UserFineBox", {
      code: code,
      userId: userId,
    })
      .then(() => {
        setMessage("You joined a finebox");
        setShowPopup(true);
      })
      .catch(() => {
        setMessage("There is no finebox with that code");
        setShowPopup(true);
      });
  };

  const createFinebox = (name: string, paymentDescription: string) => {
    post("/FineBox", {
      name: name,
      paymentDescription: paymentDescription,
      userId: userId,
    })
      .then(() => {
        setMessage("You created a finebox");
        setShowPopup(true);
      })
      .catch(() => {
        setMessage("Something wrong happend");
        setShowPopup(true);
      });
  };

  return (
    <View style={styles.container}>
      <ViewDivider returnView={(bol) => changeView(bol)}></ViewDivider>
      {createView ? (
        <CreateFineboxForm createFinebox={createFinebox}></CreateFineboxForm>
      ) : (
        <JoinFineboxForm joinFinebox={joinFinebox}></JoinFineboxForm>
      )}
      <StyledPopup
        close={() => setShowPopup(false)}
        message={message}
        isVisible={showPopup}
      ></StyledPopup>
    </View>
  );
}

export default CreateFinebox;
