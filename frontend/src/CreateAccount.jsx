import React from 'react';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import './CreateAccount.css';

function CreateAccount() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [baseUrl, setBaseUrl] = useState('');

  const addUser = async(e) => {
    e.preventDefault();
    
    if(name.trim().length <= 0) {
      alert('Name is required! Please enter your full name to create an account.');
      return;
    }
    if(password !== confirmPassword) {
      alert('Passwords do not match. Please ensure both passwords are identical and try again.');
      return;
    }
    if(password.includes(' ')) {
      alert('Spaces are not permitted in passwords! Please remove all spaces from your password and try again.');
      return;
    }

    name = name.trim(); // Remove unnecessary spaces from name
    userName = userName.trim(); // Remove unnecessary spaces from username

    // try {
    //   const response = await fetch(`${baseUrl}/users/register`,)
    // }

  }

  return (
    <div className='create-account'>
      <h1 className='create-account-header'>Create an account</h1>
        <div className='account-info-box'>
            <form onSubmit={addUser}>
                <input type='text' className='credential-input' id='name' placeholder='Enter your name' 
                  onChange={(e) => setName(e.target.value)}></input><br></br>
                <input type='email' className='credential-input' id='email' placeholder='Enter your email' 
                  onChange={(e) => setEmail(e.target.value)}></input><br></br>
                <input type='text' className='credential-input' id='username' placeholder='Create a username' 
                  onChange={(e) => setUserName(e.target.value)}></input><br></br>
                <input type='password' className='credential-input' id='password' placeholder='Create a password' 
                  onChange={(e) => setPassword(e.target.value)}></input><br></br>
                <input type='password' className='credential-input' id='password-confirmation' placeholder='Retype password' 
                  onChange={(e) => setConfirmPassword(e.target.value)}></input><br></br>
                <input type='submit' value='Submit' className='submit-btn'></input>
            </form>
        </div>
    </div>
  )
}

export default CreateAccount;