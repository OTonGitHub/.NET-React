import React from 'react';
import './App.css';
import { ducks } from './Sandbox/demo';

function App() {
  return (
    // returns JSX, cannot return siblings.
    <>
      <h1>The Man In The High Castle</h1>
      {React.createElement(
        'div',
        { className: 'TEST' },
        React.createElement('h1', null, 'Compiled.')
      )}
      {console.log('App.tsx')}
      {/* map: callback function on iter */}
      {/*ducks.map((duck) => duck.makeSound("APP"))*/}
      {ducks.map((duck) => (
        <div key={duck.name}>
          {/* need key for looping elements in jsx */}
          <span>{duck.name}</span>
          {/* call back needed for on click */}
          {/* Because, requires a function reference, not  a call */}
          <button onClick={() => duck.makeSound(duck.name + ': ' + 'quack')}>
            Make Sound
          </button>
        </div>
      ))}
    </>
  );
}

export default App;
