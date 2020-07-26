import React from "react";
import { createStackNavigator } from '@react-navigation/stack';
import { NavigationContainer } from '@react-navigation/native';

import ToDos from "./src/components/ToDos"
import Login from "./src/components/Login"

const Stack = createStackNavigator();

function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen name="Login" component={Login} />
        <Stack.Screen name="ToDos" component={ToDos} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}

export default App;