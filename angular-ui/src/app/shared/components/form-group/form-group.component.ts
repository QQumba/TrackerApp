import { Component, OnInit } from '@angular/core';
import {
  ControlContainer,
  FormBuilder,
  FormGroup,
  FormGroupDirective,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-form-group',
  templateUrl: './form-group.component.html',
  styleUrls: ['./form-group.component.scss'],
  viewProviders: [
    { provide: ControlContainer, useExisting: FormGroupDirective },
  ],
})
export class FormGroupComponent implements OnInit {
  parentForm!: FormGroup;
  constructor(private parent: FormGroupDirective, private fb: FormBuilder) {}

  ngOnInit(): void {
    // this.parentForm = this.parent.form;
    // this.parentForm.addControl(
    //   'general',
    //   this.fb.group({
    //     title: ['', Validators.required],
    //   })
    // );
  }
}
