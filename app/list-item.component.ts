import { Component, Input } from '@angular/core';
import { ListItem } from './list-item'

@Component({
  selector: 'list-item-detail',
  template: `
        <span *ngIf="listItem">{{listItem.title}}</span>
    `
})
export class ListItemDetailComponent {
    @Input()
    listItem: ListItem;
}

@Component({
  selector: 'list-item-edit',
  template: `
        <input [(ngModel)]="listItem.title" placeholder="title" />
    `
})
export class ListItemEditComponent {
    @Input()
    listItem: ListItem;
}