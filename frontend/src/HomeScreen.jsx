import React from 'react';
import { Link } from 'react-router-dom';
import './HomeScreen.css';

function HomeScreen() {
  return (
    <div className='home-screen'>
        <div className='welcome-container'>
            <h1 className='welcome-msg'>Welcome to TownVoice</h1>
            <h2 className='welcome-msg-subtitle'>Connecting communities with the governments that represent them.</h2>
            <Link className='go-to-sign-in-btn' to='/sign-in'>Sign in to your local community</Link>
        </div>
    </div>
  )
}

export default HomeScreen;
