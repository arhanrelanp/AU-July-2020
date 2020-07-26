import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import {  FormControl,FormGroup, FormBuilder, Validators} from "@angular/forms";
import { DatasetService } from '../dataset.service';

@Component({
  selector: 'app-third',
  templateUrl: './third.component.html',
  styleUrls: ['./third.component.scss']
})
export class ThirdComponent implements OnInit {

  
  constructor(private fb : FormBuilder,private dataset: DatasetService) { }

  userform = this.fb.group({
    Fname : ['',Validators.required],
    Lname : ['',Validators.required],
    age : ['', [Validators.required,Validators.min(1),Validators.max(60)]],
    city : [''],
    Empid : ['',Validators.required]
  });


  @Output()
  Emitevent = new EventEmitter<string>();

  @Output()
  ToggleEvent = new EventEmitter<string>();

  ngOnInit(): void {
  }
  toggleinner()
  {
    console.log("inside toggle");
    this.ToggleEvent.emit("1212"); 
  }

  insert(){
    this.userform.reset();
    
    this.userform.get("Empid").enable();
  }
  update(item)
  {
    console.log("upadte",item);
    this.userform.setValue(item);
    this.userform.get("Empid").disable();
  }
  onSubmit()
  {
    this.userform.get("Empid").enable();
    let key = this.userform.value.Empid;
    console.log(key);
    this.dataset.additem(key,this.userform.value);
    this.Emitevent.emit('load');
  }
}
