import React, { useEffect, useState } from "react";
import { View, StyleSheet } from "react-native";
import StyledTextfield from "../components/extras/StyledTextfield";
import { useAuth } from "../contexts/AuthContext";
import { Icon } from "react-native-elements";
import { Button } from "react-native-elements/dist/buttons/Button";
import { get } from "../ajax";

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#234E70",
  },
});

function Home({ navigation }: any) {
  const { userId } = useAuth();
  const [search, setSearch] = useState<string>();
  const [fineboxes, setFineboxes] = useState([]);

  const onAddClick = () => {
    navigation.navigate("Create Finebox");
  };

  useEffect(() => {
    get(`/User/${userId}`);
  }, []);

  return (
    <View style={styles.container}>
      <View style={{ flexDirection: "row", width: "80%" }}>
        <StyledTextfield
          onChange={(val) => setSearch(val)}
          placeholder="Search"
        ></StyledTextfield>
        <Button
          onPress={onAddClick}
          style={{ marginTop: 5, marginLeft: 5 }}
          icon={{
            name: "add",
            size: 40,
            color: "#EEA47FFF",
          }}
        />
      </View>
    </View>
  );
}

export default Home;
