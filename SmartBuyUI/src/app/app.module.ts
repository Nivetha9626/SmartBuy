import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductModule } from './product/product.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MyGridModule } from './my-grid/my-grid.module';
import { HttpClientModule } from '@angular/common/http';
import { ProductService } from './services/product.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ProductModule,
    MyGridModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
    ],
    providers:[ProductService],
    bootstrap: [AppComponent]
})
export class AppModule { }
