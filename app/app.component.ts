
import { Component } from '@angular/core';
import { ListItem, LIST_ITEMS } from './list-item'
import { ListItemEditComponent, ListItemDetailComponent } from './list-item.component'


@Component({
  selector: 'shoplister-app',
  template: `
    <h1>ShopLister</h1>
    <h2>Existing items:</h2>
    <ul>
        <li *ngFor="let listItem of listItems" (click)="onSelect(listItem)">
            <list-item-edit [listItem]="listItem" *ngIf="listItem===selected"></list-item-edit>
            <list-item-detail [listItem]="listItem" *ngIf="listItem!==selected"></list-item-detail>
        </li>
    </ul>
    `
})
export class AppComponent 
{
    selected : ListItem;
    listItems = LIST_ITEMS;

    onSelect(item : ListItem) : void {
        this.selected = item;
    }
}