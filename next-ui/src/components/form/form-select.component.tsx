import { IssueCreate } from '@/pages/issues/models/issues';
import { forwardRef } from 'react';
import { UseFormRegister } from 'react-hook-form';

const FormSelect = forwardRef<
  HTMLSelectElement,
  { label: string } & ReturnType<UseFormRegister<IssueCreate>>
>(({ onChange, onBlur, name, label }, ref) => {
  const options = ['1', '2'].map((option) => (
    <option key={option} value={option}>
      {option}
    </option>
  ));

  return (
    <>
      <label>{label}</label>
      <select
        name={name}
        ref={ref}
        onChange={onChange}
        onBlur={onBlur}
        className="rounded border-2 p-1 outline-slate-400"
      >
        {options}
      </select>
    </>
  );
});

FormSelect.displayName = 'FormSelect';

export default FormSelect;
