import { Cancel, Clear, KeyboardArrowDown } from '@mui/icons-material';
import { collapseClasses } from '@mui/material';
import { useState } from 'react';

type Chip<T> = {
  id: number;
  value?: T;
  text: string;
};

export default function Multiselect() {
  const defaultOptions: Chip<string>[] = [
    { id: 1, text: 'chip' },
    { id: 2, text: 'chop' },
  ];

  const [options, setOptions] = useState<Chip<string>[]>(defaultOptions);
  const [input, setInput] = useState<string>('');
  const [expanded, setExpanded] = useState<boolean>();

  const clear = (id: number) => () => {
    setOptions((o) => o.filter((x) => x.id != id));
  };

  function clearAll() {
    setOptions([]);
  }

  function addChip() {
    const maxId = options.length > 0 ? options[options.length - 1].id + 1 : 1;

    const option: Chip<string> = {
      id: maxId,
      text: input,
    };

    setInput('');
    setOptions((o) => [...o, option]);
  }

  function toggleExpanded() {
    setExpanded(!expanded);
  }

  return (
    <div
      onBlur={(e) => {
        const target = e.currentTarget;
        if (!target.contains(document.activeElement)) {
          setExpanded(false);
        }
      }}
      className="relative"
    >
      <label>
        Tags <span className="text-red-500">*</span>
      </label>
      <div
        className={`flex justify-between ${
          expanded ? 'rounded-b-none' : ''
        } rounded border-2 outline-slate-400`}
      >
        <div className="flex w-full flex-wrap items-stretch">
          {options.map((option) => (
            <div
              className="m-1 flex items-center rounded bg-gray-200 text-sm"
              key={option.id}
            >
              <div className="mx-1 flex h-full items-center">{option.text}</div>
              <button
                type="button"
                onClick={clear(option.id)}
                className="flex h-full items-center rounded-r p-1 transition-colors hover:bg-red-400 hover:text-red-800"
              >
                <Clear fontSize="inherit"></Clear>
              </button>
            </div>
          ))}

          <div className="grow">
            <input
              value={input}
              onFocus={() => setExpanded(true)}
              onChange={(e) => setInput(e.target.value)}
              type="text"
              className="h-full w-full p-1 outline-none"
              placeholder="Search..."
            />
          </div>
        </div>
        <div className="flex">
          <button
            type="button"
            onClick={clearAll}
            className="p-1 text-gray-400 transition-colors hover:text-gray-600"
          >
            <Clear></Clear>
          </button>
          <button
            type="button"
            onClick={toggleExpanded}
            className="border-l-2 p-1 text-gray-400 transition-colors hover:bg-gray-200 hover:text-gray-600"
          >
            <KeyboardArrowDown></KeyboardArrowDown>
          </button>
        </div>
      </div>
      <div
        className={`${
          expanded ? '' : 'hidden'
        } absolute top-full w-full rounded rounded-t-none border-2 border-t-0 bg-white p-1`}
      >
        {options.map((o) => (
          <div
            key={o.id}
            className="curs cursor-pointer rounded p-1 hover:bg-gray-200"
          >
            {o.text}
          </div>
        ))}
      </div>
    </div>
  );
}
