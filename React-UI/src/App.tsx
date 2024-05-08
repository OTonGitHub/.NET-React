import React from 'react';
import './App.css';
import { ducks } from './Sandbox/demo';
import DuckBox from './Sandbox/DuckBox';
import OTCard, { OTi } from './OT/OT';

const OT: OTi = {
  NID: "A000001",
  name: "OT'iana",
  currency: "MVR",
  price: 200
}

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
      {/* "intrinsic attributes" means prop passed to html not supported */}
      {ducks.map((duck) => (
        <DuckBox duck={duck} key={duck.name} />
      ))}

      <h1>OT Card</h1>
      <OTCard OT={OT}/>
    </>
  );
}

export default App;
