import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';

export default function MyApp({ Component, pageProps }: { Component: any; pageProps: any }) {
  return (
    <>
      <Component {...pageProps} />
      <ToastContainer />
    </>
  );
}
