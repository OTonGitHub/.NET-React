import React, { useEffect, useState } from 'react';
import './App.css';
import { ducks } from './Sandbox/demo';
import DuckBox from './Sandbox/DuckBox';
import OTCard, { OTi } from './OT/OT';
import axios from 'axios';
import { Header, List, ListItem } from 'semantic-ui-react';

const OT: OTi = {
  NID: 'A000001',
  name: "OT'iana",
  currency: 'MVR',
  price: 200,
};

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://127.0.0.1:5000/api/activities').then((response) => {
      setActivities(response.data);
    });
    // dependencies, will execute once, then again if deps change.
  }, []);

  return (
    // returns JSX, cannot return siblings.
    // icon = 'users'
    <>
      <Header as='h1' icon='address card' content='Semantic Header' />
      <List animated={true} relaxed={true} bulleted={true}>
        {activities.map((activity: any) => (
          <ListItem key={activity.id}>{activity.title}</ListItem>
        ))}
      </List>

      <h1>Reactivities</h1>
      <ul>
        {activities.map((activity: any) => (
          <li key={activity.id}>{activity.title}</li>
        ))}
      </ul>

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
      <OTCard OT={OT} />
    </>
  );
}

export default App;
