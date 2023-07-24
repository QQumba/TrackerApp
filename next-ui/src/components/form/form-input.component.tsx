import { IssueCreate } from '@/pages/issues/models/issues';
import { forwardRef, useEffect } from 'react';
import { FieldError, UseFormRegister } from 'react-hook-form';

const FormInput = forwardRef<
  HTMLInputElement,
  {
    label: string;
    placeholder: string;
    error: FieldError | undefined;
  } & ReturnType<UseFormRegister<IssueCreate>>
>(({ onChange, onBlur, name, label, placeholder, error }, ref) => {
  useEffect(() => {
    console.log(error);
  }, [error]);

  return (
    <>
      <label>
        {label} <span className="text-red-500">*</span>
        <input
          onChange={onChange}
          onBlur={onBlur}
          name={name}
          ref={ref}
          placeholder={placeholder}
          type="text"
          className="block w-full rounded border-2 p-1 outline-slate-400"
        />
      </label>
      {error && <p className="text-xs text-red-500">{error?.message}</p>}
    </>
  );
});

FormInput.displayName = 'FormInput';
export default FormInput;
