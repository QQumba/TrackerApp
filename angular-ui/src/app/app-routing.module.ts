import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'issues',
    loadChildren: () =>
      import('./features/issue-tracker/issue-tracker.module').then(
        (m) => m.IssueTrackerModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule, HttpClientModule],
})
export class AppRoutingModule {}
