import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ProductDto } from 'src/app/models/ProductDto';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  constructor(private productSvc: ProductService, private router: Router) {

  }
  public gridData: Array<ProductDto>[];
  ngOnInit(): void {
    debugger
    this.getProducts();
  }

  getProducts() {
    debugger
    // we have to call our api
    this.productSvc.getProducts().subscribe((data: any) => {
      console.log(data);
      this.gridData = data;
    }, (err: any) => {
      console.log(err)
    });
  }
  deleteSelectedRecord(id: Guid) {
    debugger
    this.productSvc.deleteProduct(id).subscribe((res)=>{
      debugger
      this.getProducts();
    },(error)=>{

      debugger
    });
  }

  editSelectedRecord(id: Guid) {
    this.router.navigate(['product/', id]);
    debugger
  }

}
