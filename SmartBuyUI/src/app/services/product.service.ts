import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductDto } from '../models/ProductDto';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private url: string = "http://localhost:5058/api/product";

  constructor(private client: HttpClient) { }

  getProducts():Observable<any> {
    debugger
   return this.client.get(this.url+'/list');
  }
  getProductbyId(id:Guid):Observable<any> {
    debugger
   return this.client.get(this.url+'/'+id);
  }
  saveProduct(product:ProductDto):Observable<any>{
    return this.client.post(this.url+'/save',product);
  }

  deleteProduct(id:Guid):Observable<any>{
    debugger
    return this.client.delete(this.url+'/'+id);
  }
}
