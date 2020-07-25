import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Router, RouterModule } from '@angular/router';
import { DatasetService } from './dataset.service';
import { ThirdComponent } from './third/third.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})



export class AppComponent implements OnInit{

  title = 'Angular-project';
  tabledata;
  displayForm:boolean = false;
  constructor(private dataset : DatasetService ){}

  emitdatahandler(str){
    
    this.ngOnInit();
        
    this.toggle();
  }
  @ViewChild(ThirdComponent) child:ThirdComponent;
  update(item)
  {
    this.toggle();
    this.child.update(item);
  }

  insert()
  {
    this.toggle();
    this.child.insert();
  }

  toggle(str?)
  {
    console.log("calling toggle outer");
    this.displayForm = ! this.displayForm;
    console.log(this.displayForm);
  }

  delete(str)
  {
    console.log("delete item",str);
    this.dataset.removeitem(str);
    this.ngOnInit();
  }
  ngOnInit()
  {
    this.tabledata = this.dataset.getAllitem();
    console.log(this.tabledata);
  }

  sortTable(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("SampleTable");
    switching = true;
    dir = "asc"; 
    while (switching) {
      switching = false;
      rows = table.rows;
      for (i = 1; i < (rows.length - 1); i++) {
        shouldSwitch = false;
        x = rows[i].getElementsByTagName("TD")[n].innerText;
        y = rows[i + 1].getElementsByTagName("TD")[n].innerText;
        if(x-y)
        {
          console.log("integer");
          x = parseInt(x);
          y = parseInt(y);
          if (dir == "asc") {
            if (x > y) {
              shouldSwitch= true;
              break;
            }
          } else if (dir == "desc") {
            if (x < y) {
              shouldSwitch = true;
              break;
            }
          }
  
        }else
        {
          console.log("string");

          if (dir == "asc") {
            if (x.toLowerCase() > y.toLowerCase()) {
              shouldSwitch= true;
              break;
            }
          } else if (dir == "desc") {
            if (x.toLowerCase() < y.toLowerCase()) {
              shouldSwitch = true;
              break;
            }
          }
  
        }
      }
      if (shouldSwitch) {
        rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
        switching = true;
        switchcount ++;      
      } else {
        if (switchcount == 0 && dir == "asc") {
          dir = "desc";
          switching = true;
        }
      }
    }
  }
}
