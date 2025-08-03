import React from 'react';

function OddPlayers({ players }) {
  const [first, , third, , fifth] = players;
  return (
    <div>
      <h2>Odd Players</h2>
      <ul>
        <li>First : {first}</li>
        <li>Third : {third}</li>
        <li>Fifth : {fifth}</li>
      </ul>
    </div>
  );
}

function EvenPlayers({ players }) {
  const [, second, , fourth, , sixth] = players;
  return (
    <div>
      <h2>Even Players</h2>
      <ul>
        <li>Second : {second}</li>
        <li>Fourth : {fourth}</li>
        <li>Sixth : {sixth}</li>
      </ul>
    </div>
  );
}

function IndianPlayers() {
  const IndianTeam = ['Sachin1', 'Dhoni2', 'Virat3', 'Rohit4', 'Yuvraj5', 'Raina6'];

  const T20Players = ['First Player', 'Second Player', 'Third Player'];
  const RanjiTrophyPlayers = ['Fourth Player', 'Fifth Player', 'Sixth Player'];

  const AllIndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

  return (
    <div>
      <OddPlayers players={IndianTeam} />
      <hr />
      <EvenPlayers players={IndianTeam} />
      <hr />
      <div>
        <h2>List of Indian Players Merged:</h2>
        <ul>
          {AllIndianPlayers.map((player, index) => (
            <li key={index}>Mr. {player}</li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default IndianPlayers;