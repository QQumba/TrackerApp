import { NgModule } from '@angular/core';
import { IssuesComponent } from './pages/issues/issues.component';
import { IssueTrackerRoutingModule } from './issue-tracker-routing.module';
import { IssueCardComponent } from './components/issue-card/issue-card.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [IssuesComponent, IssueCardComponent],
  imports: [SharedModule, IssueTrackerRoutingModule],
})
export class IssueTrackerModule {}
