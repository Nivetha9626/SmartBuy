import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { IndexComponent } from './index/index.component';
import { ProductComponent } from './product/product.component';
import { MyGridModule } from '../my-grid/my-grid.module';
import { ProductService } from '../services/product.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    IndexComponent,
    ProductComponent
  ],
  exports:[
    IndexComponent,
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MyGridModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[ProductService],
})
export class ProductModule { }
