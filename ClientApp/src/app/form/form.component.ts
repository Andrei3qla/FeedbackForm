import {Component, Inject} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

interface Subject {
  subjectId: number;
  subjectName: string;
}

class FeedbackRequest {
  public id: number;
  name: string;
  email: string;
  phone: string;
  subjectId: number;
  message: string;
}

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = environment.apiUrl;
    this.sharedKey = '6Ld_KtcUAAAAAOQgrVYPNFTUl0uYyyYI8HJeXk13';
    this.captchaURL = 'https://www.google.com/recaptcha/api/siteverify';
    const observable = this.getSubjects();
    observable.subscribe(subs => this.subjects = subs);
  }

  userData = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern('^[a-z0-9._%+-]+\@+[a-z0-9.-]+\.[a-z]{2,4}$')]),
    name: new FormControl('', [
      Validators.required,
      Validators.pattern('^[А-яа-яA-za-z ]{3,}$')]),
    phone: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]{10}$')]),
    subject: new FormControl('', [
      Validators.required]),
    message: new FormControl('', [
      Validators.required]),
    recaptcha: new FormControl('', [
      Validators.required])
  });

  posted = false;
  clicked = false;
  url: string;
  retained: object;
  sharedKey: string;
  captchaURL: string;
  subjects: Subject[];

  getSubjects(): Observable<Subject[]> {
    console.log(`clicked!`);
    return this.http.get<Subject[]>(this.url + `/subjects`);
  }

  resolved(captchaResponse: string) {

  }

  isButtonDisabled(): boolean {
    return !this.userData.valid;
  }

  public press(): void {
    this.clicked = true;
    let body = new FeedbackRequest();
    body.name = this.userData.get('name').value;
    body.email = this.userData.get('email').value;
    body.phone = this.userData.get('phone').value;
    body.subjectId = this.subjects.find(s => s.subjectName == this.userData.get('subject').value).subjectId;
    body.message = this.userData.get('message').value;


    this.http.post(this.url, body)
      .subscribe((data) => {
        this.retained = data;
        this.posted = true;
        return data;
      });
  }

}
