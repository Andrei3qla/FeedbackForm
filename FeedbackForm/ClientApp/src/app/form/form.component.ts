import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})


export class FormComponent {

  userData = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+\@+[a-z0-9.-]+\.[a-z]{2,4}$")]),
    name: new FormControl('', [
      Validators.required,
      Validators.pattern("^[А-яа-яA-za-z ]{3,}$")]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern("^[0-9]{10}$")]),
    subject: new FormControl('', [
      Validators.required]),
    message: new FormControl('', [
      Validators.required]),
    recaptcha: new FormControl('', [
      Validators.required ])
  });

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  posted: boolean = false;
  url: string;
  retained: object;

  resolved(captchaResponse: string) {
    console.log(`Resolved captcha with response: ${captchaResponse}`);
  }

  isButtonDisabled(): boolean {
    return !this.userData.valid;
  }

  public press(): void {
    const body = {
      id: 0,
      name: this.userData.get('name').value,
      email: this.userData.get('email').value,
      phone: this.userData.get('phone').value,
      subject: this.userData.get('subject').value,
      message: this.userData.get('message').value
    }

    this.http.post(this.url + 'userdatas',body)
      .subscribe((data) => {
        this.retained = data;
        this.posted = true;
        return data;
      })
  }

}
