import { createIssue } from '@/pages/issues/issues-api';
import { Issue, IssueCreate } from '@/pages/issues/models/issues';
import { useForm } from 'react-hook-form';

export default function IssueCreateForm({
  onIssueCreated,
}: {
  onIssueCreated: (issue: Issue) => void;
}) {
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<IssueCreate>();
  const submit = (data: IssueCreate) => {
    createIssue(data).then(onIssueCreated);
    console.log(data);
  };

  return (
    <form
      method="post"
      onSubmit={handleSubmit(submit)}
      className="m-auto flex max-w-xl flex-col justify-center rounded-xl border p-4 font-montserrat shadow-lg"
    >
      <h2 className="text-lg font-bold">Create issue with form</h2>

      <label>
        Title <span className="text-red-500">*</span>
      </label>
      <input
        {...register('title', {
          required: 'Title is required',
          minLength: {
            value: 3,
            message: 'Title should be at least 3 characters long',
          },
        })}
        type="text"
        placeholder="title"
        className="rounded border-2 p-1 outline-slate-400"
      />
      {errors.title && (
        <p className="text-xs text-red-500">{errors.title?.message}</p>
      )}

      <label>
        Description <span className="text-red-500">*</span>
      </label>
      <input
        {...register('description', {
          required: 'Description is required',
          minLength: {
            value: 3,
            message: 'Description should be at least 3 characters long',
          },
        })}
        type="text"
        placeholder="description"
        className="rounded border-2 p-1 outline-slate-400"
      />
      {errors.description && (
        <p className="text-xs text-red-500">{errors.description?.message}</p>
      )}

      <button
        type="submit"
        className="mb-4 mt-4 rounded border-2 p-1 transition-colors hover:bg-slate-200"
      >
        Create
      </button>
    </form>
  );
}
