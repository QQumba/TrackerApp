import { createIssue } from '@/pages/issues/issues-api';
import { Issue, IssueCreate } from '@/pages/issues/models/issues';
import { useForm } from 'react-hook-form';
import FormInput from '../form/form-input.component';

export default function IssueCreateForm({
  onIssueCreated,
}: {
  onIssueCreated: (issue: Issue) => void;
}) {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<IssueCreate>({ criteriaMode: 'all' });

  const submit = (data: IssueCreate) => {
    createIssue(data).then(onIssueCreated);
    console.log(data);
  };

  function onCreateIssue() {
    const issue: IssueCreate = {
      title: 'test',
      description: 'created with next',
      tags: [],
    };

    createIssue(issue).then(onIssueCreated);
  }

  return (
    <form
      method="post"
      onSubmit={handleSubmit(submit)}
      className="mb-4 flex w-full flex-col justify-center rounded-xl border p-4 font-montserrat shadow-lg"
    >
      <div className="flex justify-between">
        <span className="self-center text-lg font-bold">
          Create issue with form
        </span>
        <span>
          <button
            onClick={onCreateIssue}
            className="rounded border-2 p-1 px-4 transition-colors hover:border-lime-500 hover:bg-lime-500"
          >
            Create new issue
          </button>
        </span>
      </div>

      <FormInput
        label="Title"
        placeholder="Title"
        error={errors.title}
        {...register('title', {
          required: 'Title is required',
          minLength: {
            value: 3,
            message: 'Title should be at least 3 characters long',
          },
          validate: {
            isTitle: (value) => value === 'title' || 'Title should be "title"',
          },
        })}
      ></FormInput>

      <FormInput
        label="Description"
        placeholder="Description"
        error={errors.description}
        {...register('description', {
          required: 'Description is required',
          minLength: {
            value: 3,
            message: 'Description should be at least 3 characters long',
          },
        })}
      ></FormInput>

      <button
        type="submit"
        className="mb-4 mt-4 rounded border-2 p-1 transition-colors hover:bg-slate-200"
      >
        Create
      </button>
    </form>
  );
}
