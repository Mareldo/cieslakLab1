import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FirstComponent } from './first/first.component';
import { StudentsComponent } from './students/students.component';
import { StudentsService } from './data-services/students.service';
import { StudentsLsService } from './data-services/students-ls.service';

@NgModule({
  declarations: [
    AppComponent,
    FirstComponent,
    StudentsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [{ provide: StudentsService, useClass: StudentsLsService }],
  bootstrap: [AppComponent]
})
export class AppModule { }
