import React from 'react';
import './App.css';
import ListofPlayers from './ListofPlayers';
import IndianPlayers from './IndianPlayers';

function App() {
  var flag = false;

  if (flag) {
    return (
      <div className="App">
        <ListofPlayers />
      </div>
    );
  } else { 
    return (
      <div className="App">
        <IndianPlayers />
      </div>
    );
  }
}

export default App;