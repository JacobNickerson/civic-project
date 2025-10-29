import { Routes, Route, Navigate } from 'react-router-dom';
import HomeScreen from './HomeScreen.jsx';
import SignInScreen from './SignInScreen.jsx';
import './App.css';

function App() {
  return (
    <div className='app-container'>
      <Routes>
        <Route path='/' element={<HomeScreen/>}/>
        <Route path='/sign-in' element={<SignInScreen/>}/>
        <Route path='*' element={<Navigate to='/' replace/>}/> 
      </Routes>
    </div>
  )
}

export default App;
