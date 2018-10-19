import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthService } from '../../core/auth/auth.service';
import { NotifierService } from '../../core/notifier/notifier.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'register.component.html'
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;

  constructor(private authService: AuthService, private notification: NotifierService, private router: Router) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
    });
  }

  register() {
    this.loading = true;
    this.authService.register(this.registerForm.value, () => {
      this.loading = false;
      this.notification.showSuccess('Account was created!', 'Create account');
      this.router.navigate(['login']);
    }, () => {
      this.loading = false;
    });
  }
}
