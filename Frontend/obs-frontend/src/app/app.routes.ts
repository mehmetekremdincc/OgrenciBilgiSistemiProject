import { Routes } from '@angular/router';
import { LoginComponent } from './login/login';
import { DashboardComponent } from './dashboard/dashboard';
import { AdminComponent } from './admin/admin';
import { ItPortalComponent } from './it-portal/it-portal';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'it-portal', component: ItPortalComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
