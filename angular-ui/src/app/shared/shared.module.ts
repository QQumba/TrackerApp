import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormInputComponent } from './components/form-input/form-input.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormGroupComponent } from './components/form-group/form-group.component';

@NgModule({
  declarations: [FormInputComponent, FormGroupComponent],
  imports: [CommonModule, ReactiveFormsModule],
  exports: [
    FormInputComponent,
    FormGroupComponent,
    CommonModule,
    ReactiveFormsModule,
  ],
})
export class SharedModule {}
