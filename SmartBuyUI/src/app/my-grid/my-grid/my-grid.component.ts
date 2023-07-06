import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-my-grid',
  templateUrl: './my-grid.component.html',
  styleUrls: ['./my-grid.component.scss']
})
export class MyGridComponent implements OnInit {

  @Input() data: any[] = [];
  @Output() recordClickedToDelete: EventEmitter<Guid> = new EventEmitter<Guid>();
  @Output() recordClickedToEdit: EventEmitter<Guid> = new EventEmitter<Guid>();

  ngOnInit(): void {
  
  }

  getColumnNames(): string[] {
    if (!this.data|| this.data.length=== 0) {
      return []; // Return an empty array if data is empty
    }

    return Object.keys(this.data[0]);
  }
  onRecordDeleteClick(id: Guid): void {
    this.recordClickedToDelete.emit(id);
  }
  onRecordEditClick(id: Guid): void {
    this.recordClickedToEdit.emit(id);
  }
}
