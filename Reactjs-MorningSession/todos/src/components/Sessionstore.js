
      export const getAllItem =  ()=>
      {
            let data =  sessionStorage.getItem("item");
            if(data == null)
             {
                       data = [];
                       return data;
             }
                  return JSON.parse(data);
      }

      export const addItem = (item) =>{
            let data = getAllItem();
            data.push(item);
            data = JSON.stringify(data);
            sessionStorage.setItem("item",data);
      }

      export const editItem = (index,item) =>{           
            let data = getAllItem();
            data[index] = item;
            data = JSON.stringify(data);
            sessionStorage.setItem("item",data);
      }

      export const deleteItem = (index) =>{         
            let data = getAllItem();
            data.splice(index,1);
            data = JSON.stringify(data);
            sessionStorage.setItem("item",data);
      }

      export const deleteAllItem = ()=>{
            sessionStorage.removeItem("item");
      }