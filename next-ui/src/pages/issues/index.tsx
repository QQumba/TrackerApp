import { useEffect, useState } from 'react';
import * as issuesApi from './issues-api';
import { Issue } from './models/issues';
import 'tailwindcss/tailwind.css';
import { IssueCard } from '@/components/issues/issue-card.component';
import IssueCreateForm from '@/components/issues/issue-create-form.component';
import Spinner from '@/components/shared/spinner.component';

const Issues = () => {
  const [issues, setIssues] = useState<Issue[]>([]);

  useEffect(() => {
    issuesApi.getAllIssues().then((data) => setIssues(data));
  }, []);

  function onIssueCreated(issue: Issue) {
    setIssues((i) => [...i, issue]);
  }

  return (
    <div className="w-full">
      <div className="m-auto flex max-w-xl flex-col items-center">
        <IssueCreateForm onIssueCreated={onIssueCreated}></IssueCreateForm>

        {issues?.length == 0 && <Spinner></Spinner>}

        {issues?.map((issue) => (
          <IssueCard
            key={issue.id}
            issue={issue}
            onDeleted={() =>
              setIssues((i) => i.filter((x) => x.id != issue.id))
            }
          ></IssueCard>
        ))}
      </div>
    </div>
  );
};

export default Issues;
