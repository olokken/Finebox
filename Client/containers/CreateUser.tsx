import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import StyledButton from "../components/extras/StyledButton";
import StyledPopup from "../components/extras/StyledPopup";
import StyledTextfield from "../components/extras/StyledTextfield";
import axios from "axios";

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
    alignItems: "center",
  },
});

function CreateUser() {
  const [name, setName] = useState<string>();
  const [email, setEmail] = useState<string>();
  const [phoneNumber, setPhoneNumber] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [visible, setVisible] = useState<boolean>(false);

  const [message, setMessage] = useState<string>("");

  const onCreateUser = async () => {
    if (name && email && phoneNumber && password) {
      axios
        .post("http://localhost:5001/User", {
          name: name,
          phoneNumber: phoneNumber,
          email: email,
          password: password,
        })
        .then(() => {
          setMessage("You created a user");
        })
        .catch(() => {
          setMessage("Something wrong happend");
        });
    } else {
      setMessage("You have to fill all the fields");
    }
    setVisible(true);
  };

  return (
    <View style={styles.container}>
      <StyledTextfield
        onChange={(text) => setName(text)}
        placeholder="Name"
      ></StyledTextfield>
      <StyledTextfield
        onChange={(text) => setEmail(text)}
        placeholder="Email"
      ></StyledTextfield>
      <StyledTextfield
        onChange={(text) => setPhoneNumber(text)}
        placeholder="PhoneNumber"
      ></StyledTextfield>
      <StyledTextfield
        onChange={(text) => setPassword(text)}
        placeholder="Password"
        isPassword={true}
      ></StyledTextfield>
      <StyledButton title="Create new user" onPress={onCreateUser} />
      <StyledPopup
        message={message}
        close={() => setVisible(false)}
        isVisible={visible}
      ></StyledPopup>
    </View>
  );
}

export default CreateUser;
