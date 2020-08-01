import React,{useState} from "react";

import       { addItem } from "./Sessionstore"
const  Todoform =(props)=>{

      const [item,setItem] = useState("");
      const add =(i)=>{
            if(item !== ""){
                  addItem(item);
                  props.load();
                  setItem("");      
            }else
                  alert("Enter some text!");

      }

      
      return (
            <div className="todoinput" style={{width:"60%", justifyContent:"center"}}>       
            <h5  >Enter Todo</h5>         

                  <div className="input" style={{width:"100%"}} >                   
                     <input type="text"  value={item} onChange={(i)=>setItem(i.target.value) } placeholder="Enter a new Todo"></input>                           
                     <button type="add"  onClick={add} >Add Todo</button>
                  </div>
            </div>);
}

export default Todoform;