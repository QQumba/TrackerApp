export default function Spinner() {
  return (
    <div
      className=" h-8 w-8 animate-spin rounded-full border-4 border-black inline-block"
      style={{ borderRight: '4px solid transparent' }}
    >
      <span className="hidden">Loading...</span>
    </div>
  );
}
