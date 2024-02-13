import { Component, Input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';


@Component({
  selector: 'app-preview-profile',
  standalone: true,
  imports: [MatIcon],
  templateUrl: './preview-profile.component.html',
  styleUrl: './preview-profile.component.scss'
})
export class PreviewProfileComponent {
  @Input() parentComponent!:any;
}
