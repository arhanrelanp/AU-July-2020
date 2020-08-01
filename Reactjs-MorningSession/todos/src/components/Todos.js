import React, { useEffect,useState} from 'react';
import Todoform from './Todoform';
import './../App.css';
import Todolist from './Todolist';
import { getAllItem } from "./Sessionstore";

const Todos = (props)=>
{
    
      const [items, setItems] = useState([]);
      
      useEffect(()=>{
            load();
      },[])

      const load = ()=>{
            setItems(getAllItem());
      }

      return (
    <div className="App">
      <div className="App-header" > 
            <Todoform load={load}/>
            <Todolist items={items} load={load}/> 
      </div>
      </div>
      );
};


export default Todos;