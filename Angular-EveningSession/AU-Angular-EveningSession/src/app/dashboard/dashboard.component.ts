import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  @Input()
  str:string;

  @Output()
  EmConstr =  new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
    console.log("Child on init")
    this.EmConstr.emit('50');
  }

}
