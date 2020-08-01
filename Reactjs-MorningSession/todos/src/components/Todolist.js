import React, { Suspense} from "react";
import { deleteAllItem } from "./Sessionstore"
const Todo = React.lazy(()=>import('./Todo.js'));

const Todolist =(props)=>{

      props.items.map((item,key)=>console.log(item,key));
      
      const clear =()=>{
            deleteAllItem();
            props.load();
      }

      return (
            <div className="todolist" style={{width:"60%", justifyContent:"center"}}>   
            <h5>Todos</h5>         
                  <div className="" style={{width:"100%"}} >                     
                  <Suspense fallback={<div>Loading...</div>}>
                   {props.items.map((item,key)=><Todo text={item} key={key} keyId={key} load={props.load}/> )}
                   </Suspense>
                   <button type="clear" className="" onClick={clear} >Clear Todos</button>
                  </div>
            </div>);
}

export default  Todolist;
