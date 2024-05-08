import { Duck } from './demo';

interface Props {
  duck: Duck;
}

// just prop: will work, but using {duck} destructures it.
// default is used as main export, because other module can import.
// ex: import DuckBox, { makeSound } from './DuckBox';
export default function DuckBox({ duck }: Readonly<Props>) {
  /* cannot use any */
  return (
    <div key={duck.name}>
      {/* need key for looping elements in jsx */}
      <span>{duck.name}</span>
      {/* call back needed for on click */}
      {/* Because, requires a function reference, not  a call */}
      <button onClick={() => duck.makeSound(duck.name + ': ' + 'quack')}>
        Make Sound
      </button>
    </div>
  );
}
