import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IssuesComponent } from './pages/issues/issues.component';
import { IssueCardComponent } from './components/issue-card/issue-card.component';

const routes: Routes = [
  {
    path: '',
    component: IssuesComponent
  },
  {
    path: 'view',
    component: IssueCardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class IssueTrackerRoutingModule {}
