Petitions Frontend Integration Notes 

This folder contains the frontend implementation of the Petitions page for the TownVoice web application. Currently, it uses mock data and local state to simulate petition creation, signing, and sorting. This document explains how to connect it to the real backend once the ASP.NET API is ready. 

1. Environment Setup 

When integrating with the backend, create a .env file in the project root directory (same level as package.json) with the following variable: 

REACT_APP_API_BASE_URL=https://localhost:7060/api 

This defines the base URL for all API requests. 
React automatically injects variables that begin with REACT_APP_ into your app at build time. 

2. Required Imports 

Before integration, the axios import and the useEffect hook are commented out at the top of PetitionsPage.js. 
When ready, uncomment these lines: 

import { useEffect, useMemo, useState } from 'react'; 
import axios from 'axios'; 
 

3. Loading Petitions from the Backend 

Current (mock, uncommented) 

const [petitions, setPetitions] = useState([]); 
// petitions are manually managed in state 
 

When integrating: 

Uncomment the following block (already included in the file): 

useEffect(() => { 
 axios 
   .get(`${process.env.REACT_APP_API_BASE_URL}/petitions`) 
   .then(res => setPetitions(res.data)) 
   .catch(err => console.error('Failed to load petitions:', err)); 
}, []); 
 

This will fetch all petitions from the backend and populate the page. 

4. Creating a Petition 

Current (mock, uncommented) 

function handleCreate({ title, description }) { 
 const newPetition = { 
   id: crypto.randomUUID(), 
   title: title.trim(), 
   description: description.trim(), 
   createdAt: new Date().toISOString(), 
   signatures: 0 
 }; 
 setPetitions(prev => [newPetition, ...prev]); 
 setShowForm(false); 
} 
 

When integrating: 

Delete or comment out the above function, then uncomment this block: 

async function handleCreate({ title, description }) { 
 try { 
   const { data } = await axios.post( 
     `${process.env.REACT_APP_API_BASE_URL}/petitions`, 
     { title, description } 
   ); 
   setPetitions(prev => [data, ...prev]); 
   setShowForm(false); 
 } catch (err) { 
   console.error('Failed to create petition:', err); 
 } 
} 
 

This sends a POST request to the backend and updates the list with the returned petition. 

5. Signing a Petition 

Current (mock, uncommented) 

function handleSign(id) { 
 setPetitions(prev => 
   prev.map(p => p.id === id ? { ...p, signatures: p.signatures + 1 } : p) 
 ); 
} 
 

When integrating (assuming backend handles the increment): 

Delete or comment out the mock version and uncomment this block: 

async function handleSign(id) { 
 try { 
   await axios.post( 
     `${process.env.REACT_APP_API_BASE_URL}/petitions/${id}/sign` 
   ); 
   const { data } = await axios.get(`${process.env.REACT_APP_API_BASE_URL}/petitions`); 
   setPetitions(data); 
 } catch (err) { 
   console.error('Failed to sign petition:', err); 
 } 
} 
 

This calls the backend to increment the signature count, then refreshes the list from the database. 

6. Sorting Petitions 

The sorting logic (recent vs popular) is currently handled on the frontend. 

7. Authentication (Future Consideration) 

The petitions page does not currently require login logic. Once authentication is added: 

The backend may require an Authorization token in the request headers. 

In that case, update Axios calls to include: 

headers: { 
 Authorization: `Bearer ${token}` 
} 

The token will be provided by the login component of the app. 

9. Notes for Backend Developers 

Endpoints expected by the frontend: 

GET /api/petitions → returns all petitions 

POST /api/petitions → creates a new petition 

POST /api/petitions/{id}/sign → increments signature count 

Each petition object should contain: 

{ 
 "id": "guid-or-int", 
 "title": "string", 
 "description": "string", 
 "createdAt": "2025-11-10T10:00:00Z", 
 "signatures": 0 
} 

Responses must be in JSON format. 

Ensure CORS allows http://localhost:3000. 

10. File Reference 

PetitionsPage.js: Main component handling display and logic 

PetitionCard.js: Individual petition UI component 

CreatePetitionForm.js: Petition creation form 

Petitions.css: Styles for petitions page 

 