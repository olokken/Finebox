import React, { useState } from "react";
import { View, StyleSheet, Image } from "react-native";
import { Text } from "react-native-elements";
import StyledButton from "../components/extras/StyledButton";
import StyledTextfield from "../components/extras/StyledTextfield";
import { useAuth } from "../contexts/AuthContext";

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
    alignItems: "center",
  },
  pic: {
    marginTop: 30,
  },
  text: {
    marginBottom: 8,
    color: "#f70000",
    fontSize: 14,
  },
});

function Login({ navigation }: any) {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [showError, setShowError] = useState<boolean>(false);
  const { signIn } = useAuth();

  const onLogin = async () => {
    await signIn(username, password)
      .then(() => {
        navigation.navigate("Home");
      })
      .catch(() => {
        setShowError(true);
      });
  };

  const onCreateUser = () => {
    navigation.navigate("Create User");
  };

  return (
    <View style={styles.container}>
      <Image style={styles.pic} source={require("../assets/chest.png")} />
      <StyledTextfield
        placeholder="Email"
        onChange={(text) => setUsername(text)}
      ></StyledTextfield>
      <StyledTextfield
        placeholder="Password"
        onChange={(text) => setPassword(text)}
        isPassword={true}
      ></StyledTextfield>
      {showError ? (
        <Text style={styles.text}>
          You have written wrong password or username
        </Text>
      ) : null}
      <StyledButton onPress={onLogin} title="Sign in"></StyledButton>
      <StyledButton
        onPress={onCreateUser}
        title="Create new user"
      ></StyledButton>
    </View>
  );
}

export default Login;
