import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ListItemEditComponent, ListItemDetailComponent } from './list-item.component'


import { AppComponent,  } from './app.component';
/* import { HeroDetailComponent } from './hero-detail.component'
*/

@NgModule({
  imports:      [ BrowserModule, FormsModule ],
  declarations: [ AppComponent, ListItemDetailComponent, ListItemEditComponent ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }