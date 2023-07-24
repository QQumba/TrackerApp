import 'tailwindcss/tailwind.css';
import { API_URL } from '@/utils/constants';
import { isResponseSuccessful } from '@/utils/http-response-helpers';
import { toast } from 'react-toastify';

export default function Testing() {
  const callInvalidApi = () => {
    fetch(API_URL + 'invalid-url').then((r) => {
      if (!r.ok) {
        toast.error('error');
      }
    });
  };

  return (
    <div className="m-4">
      <div className="font-bold">Erorr handling testing component</div>
      <button className="rounded border-2 p-1" onClick={callInvalidApi}>
        Call invalid api
      </button>
    </div>
  );
}
