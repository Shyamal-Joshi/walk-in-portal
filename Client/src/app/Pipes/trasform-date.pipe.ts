import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'transformDate',
  standalone: true
})
export class TransformDatePipe implements PipeTransform {

  transform(value: Date): string | null {
    if(!value) return '';

    const date = new Date(value);
    return new DatePipe('en-US').transform(date, 'dd-MMMM-yyyy')
  }

}
