# API Documentation
This file contains documentation for all the various API endpoints.

Base URL: https://PENDINGDOMAINNAME.com/api

---

## User Authentication
### GET `/{id}`
**Description:** Get a user by their ID

### POST `/register`
**Description:** Register a new user account

**Request Body (JSON):**
```json
{
    "username": "example_user",
    "email": "example@email.com",
    "password": "P@ssw0rd!"
}
```

**Responses:**
200 Ok
400 Bad Request
409 Conflict

### Post `/login`
**Description:** Login using an existing user account and password

**Request Body (JSON):**
```json
{
    "username": "example_user",
    "password": "P@ssw0rd!"
}
```

**Responses:**
200 Ok
```json
{
    "token": "jwttokenhere",
    "userid": 1 
}
```
400 Bad Request
401 Unauthorized
