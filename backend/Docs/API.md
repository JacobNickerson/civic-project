# API Documentation
This file contains documentation for all the various API endpoints.

Base URL: https://PENDINGDOMAINNAME.com/api

---

## User Authentication
### GET `/{id}`
**Description:** Get a user by their ID

**Responses:**
200 Ok
```json
{
    "id" = 1,
    "username": "example_user",
    "name": "Example User",
    "profilepic": "https://optionalprofilepicturelink.com/",
    "bio": "This is my optional bio to be displayed on my account"
}
```
404 Not Found

### POST `/register`
**Description:** Register a new user account

**Request Body (JSON):**
```json
{
    "username": "example_user",
    "name": "Example User",
    "email": "example@email.com",
    "password": "P@ssw0rd!",
    "profilepic": "https://optionalprofilepicturelink.com/",
    "bio": "This is my optional bio to be displayed on my account"
}
```
Fields `username`, `name`, `email`, `password` are required, while `profilepic` and `bio` are optional and
will be set to null if left blank.

**Responses:**
200 Ok
```json
{
    "id" = 1,
    "username": "example_user",
    "name": "Example User",
    "profilepic": "https://optionalprofilepicturelink.com/",
    "bio": "This is my optional bio to be displayed on my account"
}
```
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
