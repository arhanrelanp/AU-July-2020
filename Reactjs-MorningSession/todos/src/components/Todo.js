import React, { useState } from "react";
import { deleteItem, editItem } from "./Sessionstore"


const  Item =(props)=>{
      const [editable, setEditable] = useState(false);
      const [editableitem, setEditableItem] = useState(props.text); 
      
      
      const edit =()=>{
            setEditable(!editable);
      }

      const save = ()=>{
            if(editableitem !== ""){
                  editItem(props.keyId,editableitem);
                  edit();
                  props.load();
            }else 
                  alert("Enter some text!");
      }

      const cancel  = ()=>{
            setEditableItem(props.text);
            edit();
      }
   
      const delete_item = ()=>{
            
            deleteItem(props.keyId);
            props.load();
      }

      return (  
      <div>         
            <div className="todo">                 
                        <input type="text" disabled={!editable} onChange={(i)=>setEditableItem(i.target.value)}  value={editableitem}/>
                        <button className="Edit" onClick={edit} hidden={editable} >Edit</button>
                        <button className="Save" onClick={save} hidden={!editable} >Save</button>
                        <button className="Cancel" onClick={cancel} hidden={!editable} >Cancel</button>
                        <button className="Delete" onClick={delete_item} >Delete</button>
                  
            </div>
      </div>
      );

}

export default  Item;