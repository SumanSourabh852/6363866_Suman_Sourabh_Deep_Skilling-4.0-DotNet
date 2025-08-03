import React, { useState } from 'react';

function EventExamples() {
  const [count, setCount] = useState(0);

  const handleIncrement = () => {
    setCount(prevCount => prevCount + 1);
    alert('Hello! Member1');
  };

  const handleDecrement = () => {
    setCount(prevCount => prevCount - 1);
  };

  const handleWelcome = (message) => {
    alert(message);
  };

  const handleClickMe = (e) => {
    alert('I was clicked');
  };

  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={handleIncrement}>Increment</button>
      <button onClick={handleDecrement}>Decrement</button>
      <button onClick={() => handleWelcome('welcome')}>Say welcome</button>
      <button onClick={handleClickMe}>Click on me</button>
    </div>
  );
}

export default EventExamples;
