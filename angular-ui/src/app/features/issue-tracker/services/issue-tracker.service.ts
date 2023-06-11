import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IssueCreate } from '../models/issue-create.model';
import { Observable, map } from 'rxjs';
import { Issue } from '../models/issue.model';

const url = 'https://localhost:5005/api/issues/';

@Injectable({
  providedIn: 'root',
})
export class IssueTrackerService {
  constructor(private client: HttpClient) {}

  createIssue(issue: IssueCreate): Observable<Issue> {
    return this.client.post<Issue>(url, issue);
  }

  getAllIssues(): Observable<Issue[]> {
    return this.client.get<Issue[]>(url);
  }

  getIssueById(id: number): Observable<Issue> {
    return this.client.get<Issue>(url + id);
  }

  deleteIssue(id: number): Observable<boolean> {
    return this.client.delete<number>(url + id).pipe(map((x) => !!x));
  }
}
