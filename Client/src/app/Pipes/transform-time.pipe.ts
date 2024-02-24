import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'transformTime',
  standalone: true
})
export class TransformTimePipe implements PipeTransform {

  transform(value: string): string | null {
    if(!value) return '';

    const date = new Date('1970-01-01T' + value);
    return new DatePipe('en-US').transform(date,'h:mm a');
  }

}
