import { BaseIdAuditEntity } from "./BaseIdAuditEntity";

export class CustomerDto extends BaseIdAuditEntity {
    firstName: string;
    lastName: string;
    dob: Date;
    email: string;
    address: string;
}
