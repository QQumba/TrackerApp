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
    <div
      key={issue.id}
      className="mb-4 flex w-full flex-grow justify-between rounded-xl border bg-gray-100 p-4"
    >
      <span>
        <div>issueId: {issue.id}</div>
        <div>title: {issue.title}</div>
        <div>description: {issue.description}</div>
        <div>
          {issue.tags?.map((tag) => (
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
        <button
          onClick={deleteIssue}
          className="rounded border-2 bg-white p-1 transition-colors hover:bg-red-600 hover:text-white"
        >
          Delete
        </button>
      </span>
    </div>
  );
}
