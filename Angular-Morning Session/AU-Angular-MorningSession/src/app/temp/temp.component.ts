import { Component, OnInit, Input, Output ,EventEmitter} from '@angular/core';

@Component({
  selector: 'app-temp',
  templateUrl: './temp.component.html',
  styleUrls: ['./temp.component.scss']
})
export class TempComponent implements OnInit {

  constructor() { }

  @Input() notifications: any[]

  ngOnInit(): void {
  }
 
 

}
