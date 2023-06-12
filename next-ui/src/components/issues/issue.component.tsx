import { Issue } from '@/pages/issues/issues.model';

export function Issue(issue: Issue) {
  return (
    <div key={issue.id}>
      <div>issueId: {issue.id}</div>
      <div>title: {issue.title}</div>
      <div>description: {issue.description}</div>
      <button className="mb-4 rounded border-2 p-1">Delete</button>
      <hr />
    </div>
  );
}
