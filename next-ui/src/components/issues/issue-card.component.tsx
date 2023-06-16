import * as issuesApi from '@/pages/issues/issues-api';
import { Issue } from '@/pages/issues/models/issues';

export function IssueCard({
  issue,
  onDeleted,
}: {
  issue: Issue;
  onDeleted: () => void;
}) {
  const deleteIssue = () => {
    issuesApi.deleteIssue(issue.id).then((_) => onDeleted());
  };

  return (
    <div key={issue.id} className="m-4 rounded-xl border p-4 flex flex-grow justify-between">
      <span>
        <div>issueId: {issue.id}</div>
        <div>title: {issue.title}</div>
        <div>description: {issue.description}</div>
        <div>
          {issue.tags.map((tag) => (
            <span
              className="mr-1 inline-block rounded-sm bg-amber-400 px-1 text-sm capitalize"
              key={tag.id}
            >
              {tag.name}
            </span>
          ))}
        </div>
      </span>
      <span>
        <button onClick={deleteIssue} className="rounded border-2 p-1">
          Delete
        </button>
      </span>
    </div>
  );
}
