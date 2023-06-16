import { API_URL } from '@/utils/constants';
import { Issue, IssueCreate } from './models/issues';

export async function getAllIssues(): Promise<Issue[]> {
  return fetch(API_URL + 'issues').then((response) => response.json());
}

export async function createIssue(issue: IssueCreate): Promise<Issue> {
  return fetch(API_URL + 'issues', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(issue),
  })
    .then((response) => {
      if (response.status > 200 && response.status < 300)
        return response.json();
    })
    .catch((error) => {
      console.log(error);
    });
}

export async function deleteIssue(issueId: number): Promise<boolean> {
  return fetch(API_URL + 'issues/' + issueId, {
    method: 'DELETE',
  }).then((_) => true);
}
