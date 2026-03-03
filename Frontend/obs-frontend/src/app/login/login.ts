import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {

      this.authService.login(this.loginForm.value)
        .subscribe({
          next: (res) => {
            console.log("Giriş başarılı:", res);
            localStorage.setItem('token', res.token);
            alert("Login başarılı!");
          },
          error: (err) => {
            console.error("Login hatası:", err);
            alert("Email veya şifre hatalı");
          }
        });
    }
  }
}
