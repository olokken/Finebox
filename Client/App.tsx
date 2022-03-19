import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import Home from "./containers/Home";
import Login from "./containers/Login";
import CreateUser from "./containers/CreateUser";
import { AuthProvider } from "./contexts/AuthContext";
import CreateFinebox from "./containers/CreateFinebox";

const Stack = createNativeStackNavigator();

export default function App() {
  return (
    <AuthProvider>
      <NavigationContainer>
        <Stack.Navigator initialRouteName="Login">
          <Stack.Screen
            name="Login"
            component={Login}
            options={{
              headerStyle: {
                backgroundColor: "#EEA47FFF",
              },
            }}
          />
          <Stack.Screen
            name="Home"
            component={Home}
            options={{
              headerStyle: {
                backgroundColor: "#EEA47FFF",
              },
            }}
          />
          <Stack.Screen
            name="Create User"
            component={CreateUser}
            options={{
              headerStyle: {
                backgroundColor: "#EEA47FFF",
              },
            }}
          />
          <Stack.Screen
            name="Create Finebox"
            component={CreateFinebox}
            options={{
              headerStyle: {
                backgroundColor: "#EEA47FFF",
              },
            }}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </AuthProvider>
  );
}
