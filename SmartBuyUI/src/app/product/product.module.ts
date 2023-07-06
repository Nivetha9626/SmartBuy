import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './product/product.component';



@NgModule({
  declarations: [
    IndexComponent,
    ProductComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductModule { }
