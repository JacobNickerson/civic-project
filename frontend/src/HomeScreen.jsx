import { useState } from 'react'
import './HomeScreen.css'

function HomeScreen() {
  const [count, setCount] = useState(0);

  return (
    <div>
        <div className='welcome-container'>
            <h1 className='welcome-msg'>Welcome to TownVoice</h1>
            <h2 className='welcome-msg-subtitle'>Connecting communities with the governments that represent them.</h2>
            <button className='go-to-sign-in-btn'>Sign in to your local community</button>
        </div>
    </div>
  )
}

export default HomeScreen;
