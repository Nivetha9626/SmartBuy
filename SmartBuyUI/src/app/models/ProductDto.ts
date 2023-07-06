import { BaseIdAuditEntity } from "./BaseIdAuditEntity";

export interface ProductDto extends BaseIdAuditEntity{
   
    name: string;
    description: string;
    price: number;
    stock: number;
}
