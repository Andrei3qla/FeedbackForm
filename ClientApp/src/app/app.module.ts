import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FormComponent } from "./form/form.component";
import { NgxMaskModule} from "ngx-mask";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatCardModule } from '@angular/material/card'
import { MatFormFieldModule, MatInputModule, MatSelectModule, MatIconModule } from '@angular/material'
import { MatTooltipModule } from '@angular/material/tooltip'

import { RecaptchaModule, RecaptchaFormsModule, RECAPTCHA_SETTINGS, RecaptchaSettings } from 'ng-recaptcha';
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [
    AppComponent,
    FormComponent
  ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        NgxMaskModule.forRoot({
            showMaskTyped: true,
        }),
        BrowserAnimationsModule,

        MatCardModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatTooltipModule,
        MatIconModule,
        RecaptchaFormsModule,
        RecaptchaModule,
        MatButtonModule
    ],
  providers: [{
    provide: RECAPTCHA_SETTINGS,
    useValue: { siteKey: 'MyOwnFeedbackForm' } as RecaptchaSettings}],
  bootstrap: [AppComponent]
})
export class AppModule { }
