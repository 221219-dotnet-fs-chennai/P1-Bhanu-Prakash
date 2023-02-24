import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SampleModule } from './sample/sample.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatTabsModule} from '@angular/material/tabs';
import {MatProgressBarModule} from '@angular/material/progress-bar';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SampleModule,
    FormsModule,
    NgbModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatRadioModule,
    MatSlideToggleModule,
    MatTabsModule,
    MatProgressBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
