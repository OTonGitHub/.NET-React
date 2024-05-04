import React from 'react';
import './App.css';

function App() {
  return (
    <>
      <h1>The Man In The High Castle</h1>
      {React.createElement(
        'div',
        { className: 'TEST' },
        React.createElement('h1', null, 'Compiled.')
      )}
    </>
  );
}

export default App;
