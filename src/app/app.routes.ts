import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { JobListingComponent } from './job-listing/job-listing.component';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: LoginComponent,
    },
    {
        path: 'registration',
        pathMatch: 'full',
        component: UserRegistrationComponent,
    },
    {
        path: 'jobs',
        pathMatch: 'full',
        component: JobListingComponent,
    },
];
