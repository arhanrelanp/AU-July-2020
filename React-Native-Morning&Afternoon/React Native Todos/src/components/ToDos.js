import React, { useEffect, useState } from 'react';
import { Text, SafeAreaView, Platform, StyleSheet, Alert,Button, AsyncStorage } from 'react-native';

import { TextInput } from 'react-native-gesture-handler';
import Show from './Show'
export default function ToDos({navigation}) {
    const [todos, setTodos] = useState("");
    const [show,setShow] =useState("");
    useEffect(() => {
        fetchTodo();
    }, [])

    const fetchTodo = async () => {
        const list = await AsyncStorage.getItem("todos");

        if(list){
            setShow(list);
        }
        
    }
    const createAlert = () =>
    Alert.alert(
        'Alert',
        'Do you want to continue?',
        [
          {
            text: 'Cancel',
            onPress: () => console.log('Cancel Pressed'),
            style: 'cancel'
          },
          { text: 'Confirm', onPress: () => console.log('Confirm Pressed') }
        ],
        { cancelable: false }
      );
    const addTodo = async () => {
        try{
        const todolist = await AsyncStorage.getItem("todos");
        console.log(todolist);
        if(todolist==null){
            var item=[];
            item.push(todos);
            await AsyncStorage.setItem('todos',JSON.stringify(item));
            await useEffect(()=>{
            fetchTodo()
            },[])
            
        // console.log(await AsyncStorage.getItem('todos'))
             
        }
        else{
            var arr = JSON.parse(todolist);
            
           arr.push(todos);
            await AsyncStorage.setItem('todos', JSON.stringify(arr));
            await useEffect(() => {
                fetchTodo()
              }, [])
            // console.log(await AsyncStorage.getItem('todos'))
              
        }
      } catch (error) {
        // Error retrieving data
      }
    }
    const deleteTodo = async () => {
        console.log("delete requested");
    
        //await AsyncStorage.clear();
         try {
             const arr = await AsyncStorage.getItem('todos');
             var newList = await JSON.parse(arr);
             console.log(newList);

             var i = await newList.indexOf(todos);
             if(i == -1){
                 return;
             }
             await newList.splice(i, 1);
             console.log(newList);
             await AsyncStorage.setItem('todos', JSON.stringify(newList));
             await useEffect(() => {
                fetchTodo()
              }, [])
             
           } catch (error) {
             // Error retrieving data
             console.log(error);
           }
        }
           
    const logout = async () => {
        const userName = await AsyncStorage.getItem("username");
        console.log(userName);
        await AsyncStorage.clear();
        navigation.navigate("Login");
    }

    return (
        <SafeAreaView style={Styles.mainContainer}>
           <TextInput style={Styles.textInputStyle} onChangeText={(text) => setTodos(text)} placeholder="Enter a todo....." />
           {fetchTodo}
            <Button title="Add Todo" onPress={()=>{addTodo(); createAlert();} } />
            <Text>{show}</Text>
            <Text>Refresh to update</Text>
            <TextInput style={Styles.textInputStyle} onChangeText={(todo) => setTodos(todo)} placeholder="Enter a todo to delete." />
            <Button title="Delete" onPress={
                () => { deleteTodo(); createAlert();}
                } /> 
            <Button title="Log out" onPress={logout} />
        </SafeAreaView>
    );
}


const Styles = StyleSheet.create({
    mainContainer:{
        flex: 1,
        justifyContent: "center",
        alignItems:"center"
    },
    title: {
        fontSize: 16,
        color: "white",
        fontWeight: "700",
        padding: 5
    },
    source: {
        fontSize: 16,
        color: "white",
        fontWeight: "700",
        padding: 5,
        alignSelf: "flex-end"
    },
    background: {
        width: "100%",
        height: "100%",
        justifyContent: "space-between"
    },
    container: {
        width: "95%",
        height: 150,
        marginLeft: "2.5%",
        marginRight: "2.5%",
        marginVertical: 5
    },
    textInputStyle: {
        borderColor: "black",
        borderWidth: 1,
        borderRadius: 5,
        fontSize: 20,
        padding: 5,
        width: "60%",
        marginBottom: 20
    }

})
