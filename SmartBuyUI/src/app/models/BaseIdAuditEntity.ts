import { Guid } from "guid-typescript";

export class BaseIdAuditEntity {
    id: Guid;
  createdBy: Guid;
  createdOn: Date;
  modifiedBy: Guid;
  modifiedOn: Date;
}
