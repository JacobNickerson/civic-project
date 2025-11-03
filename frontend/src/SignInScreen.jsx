import React from 'react';
import { Link } from 'react-router-dom';
import './SignInScreen.css';

function SignInScreen() {
    return(
        <div className='sign-in-screen'>
            <h1 className='sign-in-header'>Sign Into Your TownVoice Community</h1>
            <div className='sign-in-box'>
                <form>
                    <input type='text' className='credential-input' id='username' placeholder='Username'></input><br></br>
                    <input type='password' className='credential-input' id='password' placeholder='Password'></input><br></br>
                    <input type='submit' value='Submit' className='submit-btn'></input>
                </form>
                <Link className='create-account-btn' to='/create-account'>Create a new account</Link>
            </div>
        </div>
    );
}

export default SignInScreen;