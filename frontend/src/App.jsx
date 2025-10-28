import { useState } from 'react';
import HomeScreen from './HomeScreen.jsx';
import './App.css';

function App() {
  const [count, setCount] = useState(0);

  return (
    <div className='app-container'>
      <HomeScreen />
    </div>
  )
}

export default App;
