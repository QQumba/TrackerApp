import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IssuesComponent } from './pages/issues/issues.component';
import { IssueTrackerRoutingModule } from './issue-tracker-routing.module';
import { IssueCardComponent } from './components/issue-card/issue-card.component';

@NgModule({
  declarations: [IssuesComponent, IssueCardComponent],
  imports: [CommonModule, IssueTrackerRoutingModule],
})
export class IssueTrackerModule {}
