import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatasetService {

  constructor() {
    let data1 = 
      {
        Fname : 'Arhan',
        Lname : 'Relan',
        age:22,
        Empid : 111,
        city:'Delhi'
      };
      let data2 = {
        Fname : 'Priyank',
        Lname : 'Ahuja',
        age:23,
        Empid : 112,
        city:'Pune'
      };
    
      sessionStorage.setItem('111',JSON.stringify(data1));
      sessionStorage.setItem('112',JSON.stringify(data2));
   }
  getitem(key:string){
    let data = sessionStorage.getItem(key);
    return JSON.parse(data);
  }
  getAllitem()
  {
    let tabledata = [];
    for(let x =0; x< sessionStorage.length; x++ )
    {
      tabledata.push(JSON.parse(sessionStorage[sessionStorage.key(x)]));
    }
    return tabledata;
  }
  additem(key:string,data){
    sessionStorage.setItem(key,JSON.stringify(data));
  }
  updateitem(key:string,data){
    this.additem(key,data);
  }

  removeitem(key:string){
    console.log("dataset reove ",key);
    sessionStorage.removeItem(key);
  }
}
