import { useEffect, useState } from 'react';
import * as issuesApi from './issues-api';
import { Issue, IssueCreate } from './models/issues';
import 'tailwindcss/tailwind.css';
import { IssueCard } from '@/components/issues/issue-card.component';
import IssueCreateForm from '@/components/issues/issue-create-form.component';

const Issues = () => {
  const [issues, setIssues] = useState<Issue[]>([]);

  useEffect(() => {
    issuesApi.getAllIssues().then((data) => setIssues(data));
  }, []);

  function createIssue() {
    const issue: IssueCreate = {
      title: 'test',
      description: 'created with next',
    };

    issuesApi.createIssue(issue).then((data) => setIssues((i) => [...i, data]));
  }

  function onIssueCreated(issue: Issue) {
    setIssues((i) => [...i, issue]);
  }

  return (
    <div>
      <button onClick={createIssue} className="rounded border-2 p-1">
        Create new issue
      </button>

      <IssueCreateForm onIssueCreated={onIssueCreated}></IssueCreateForm>

      {issues.map((issue) => (
        <IssueCard
          key={issue.id}
          issue={issue}
          onDeleted={() => setIssues((i) => i.filter((x) => x.id != issue.id))}
        ></IssueCard>
      ))}
    </div>
  );
};

export default Issues;
