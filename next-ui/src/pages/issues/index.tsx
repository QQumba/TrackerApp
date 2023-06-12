import { useEffect, useState } from 'react';
import * as issuesApi from './issues-api';
import { Issue, IssueCreate } from './issues.model';
import 'tailwindcss/tailwind.css';

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

  const deleteIssue = (issueId: number) => () => {
    issuesApi
      .deleteIssue(issueId)
      .then((_) => setIssues((i) => i.filter((x) => x.id != issueId)));
  };

  function onSubmit(e: any) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);
    const formDataObject = Object.fromEntries(formData.entries());

    const issue: Issue = JSON.parse(JSON.stringify(formDataObject));
    issuesApi.createIssue(issue).then((data) => setIssues((i) => [...i, data]));

    form.reset();
  }

  return (
    <div>
      <button onClick={createIssue} className="rounded border-2 p-1">
        Create new issue
      </button>

      <form
        method="post"
        onSubmit={onSubmit}
        className="m-auto flex max-w-xl flex-col justify-center rounded-xl border p-4 font-montserrat shadow-lg"
      >
        <h2 className="font-bold text-lg">Create issue with form</h2>
        <label>
          Title <span className="text-red-500">*</span>
        </label>
        <input
          name="title"
          type="text"
          placeholder="title"
          className="rounded border-2 p-1 outline-slate-400"
        />
        <label>
          Description <span className="text-red-500">*</span>
        </label>
        <input
          name="description"
          type="text"
          placeholder="description"
          className="mb-4 rounded border-2 p-1 outline-slate-400"
        />
        <button
          type="submit"
          className=" mb-4 rounded border-2 p-1 transition-colors hover:bg-slate-200"
        >
          Create
        </button>
      </form>

      {issues.map((issue) => (
        <div key={issue.id}>
          <div>issueId: {issue.id}</div>
          <div>title: {issue.title}</div>
          <div>description: {issue.description}</div>
          <button
            onClick={deleteIssue(issue.id)}
            className="mb-4 rounded border-2 p-1"
          >
            Delete
          </button>
          <hr />
        </div>
      ))}
    </div>
  );
};

export default Issues;
