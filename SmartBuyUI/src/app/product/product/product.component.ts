import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ProductDto } from 'src/app/models/ProductDto';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  public form: FormGroup;
  public isAdd: boolean = true;
  public id: Guid;
  product: ProductDto;
  constructor(public fb: FormBuilder, private router: Router,
    private route: ActivatedRoute, private productSvc: ProductService) {

  }
  ngOnInit(): void {
    debugger
    this.id = this.route.snapshot.params['id'] as Guid;

    if (this.id) {
      this.isAdd = false;
      this.getProductbyId();
    }
    this.form = this.fb.group({
      id: [Guid.EMPTY],
      name: ['', Validators.required],
      description: ['', Validators.required],
      stock: [0, [Validators.required]],
      price: [0, Validators.required],
      createdBy: [Guid.EMPTY],
      createdOn: [new Date()]
    });
  }
  getProductbyId() {
    this.productSvc.getProductbyId(this.id).subscribe((data: any) => {
      console.log(data);
      this.form.patchValue(data) ;
    }, (err: any) => {
      console.log(err)
    });
  }

  onSubmit() {
    debugger
    this.form.markAllAsTouched();
    if (this.form.invalid) {
      return;
    }

    this.product = this.form.getRawValue() as ProductDto;
    this.productSvc.saveProduct(this.product).subscribe((res) => {
      debugger
      this.router.navigateByUrl('product');
    }, (error) => {
      debugger
    });

  }
}
