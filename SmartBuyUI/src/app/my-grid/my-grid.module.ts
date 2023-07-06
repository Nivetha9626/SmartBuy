import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyGridComponent } from './my-grid/my-grid.component';



@NgModule({
  declarations: [
    MyGridComponent
  ],
  exports:[MyGridComponent],
  imports: [
    CommonModule
  ]
})
export class MyGridModule { }
