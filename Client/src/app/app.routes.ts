import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { JobListingComponent } from './job-listing/job-listing.component';
import { JobComponentComponent } from './job-component/job-component.component';
import { JobConfirmationComponentComponent } from './job-confirmation-component/job-confirmation-component.component';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: LoginComponent,
    },
    {
        path: 'login',
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
    {
        path: 'job/:id',
        pathMatch: 'full',
        component: JobComponentComponent,
    },
    {
        path: 'confirm',
        pathMatch: 'full',
        component:JobConfirmationComponentComponent
    }
];
