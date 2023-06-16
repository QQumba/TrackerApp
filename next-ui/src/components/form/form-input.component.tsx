// TODO: add htmlFor to label

export function FormInput({
  label,
  name,
  placeholder,
}: {
  label: string;
  name: string;
  placeholder: string;
}) {
  return (
    <label>
      {label} <span className="text-red-500">*</span>
      <input
        name={name}
        type="text"
        placeholder={placeholder}
        className="block w-full rounded border-2 p-1 outline-slate-400"
      />
    </label>
  );
}
