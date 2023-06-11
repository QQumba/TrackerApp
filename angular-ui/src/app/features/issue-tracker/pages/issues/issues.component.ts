import { Component } from '@angular/core';
import { IssueTrackerService } from '../../services/issue-tracker.service';
import { Observable } from 'rxjs';
import { Issue } from '../../models/issue.model';
import {
  ControlContainer,
  FormControl,
  FormGroup,
  FormGroupDirective,
  Validators,
} from '@angular/forms';
import { IssueCreate } from '../../models/issue-create.model';

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.scss'],
})
export class IssuesComponent {
  // issues$: Observable<Issue[]>;
  issues: Issue[] = [];

  issueForm = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
  });

  constructor(private issueService: IssueTrackerService) {
    // this.issues$ = issueService.getAllIssues();
    issueService.getAllIssues().subscribe((x) => (this.issues = x));
  }

  createIssue(): void {
    this.issueService
      .createIssue(this.issueForm.value as IssueCreate)
      .subscribe((x) => this.issues.push(x));
  }

  deleteIssue(id: number): void {
    this.issueService.deleteIssue(id).subscribe((x) => {
      const index = this.issues.findIndex((i) => i.issueId == id);
      this.issues.splice(index, 1);
    });
  }
}
