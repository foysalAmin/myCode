# Ecom Public API

- [Ecom Public API](#ecom-public-api)
  - [Auth](#auth)
    - [Registration](#registration)
      - [Registration Request](#registration-request)
      - [Registration Response](#registration-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Registration

```js
POST /auth/registration
```

#### Registration Request

```json
{
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "password": "aranab1232!"
}
```

#### Registration Response

```js
200 OK
```

```json
{
  "id": "a0df6e09-1ade-44ea-896d-c3b70cb7ed05",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhMGRmNmUwOS0xYWRlLTQ0ZWEtODk2ZC1jM2I3MGNiN2VkMDUiLCJnaXZlbl9uYW1lIjoiTWQuIEFyYWZhdCBSYWhtYW4iLCJmYW1pbHlfbmFtZSI6IlJhbmEiLCJqdGkiOiI4NDQwMDg2NC1kMzc1LTRjOWYtOWUwMC0yMjdmNDhiZjY4YTciLCJleHAiOjE2OTAwMDMwMjUsImlzcyI6IkVjb21QdWJsaWNBcGkiLCJhdWQiOiJFY29tUHVibGljQXBpIn0.KsHD4wDSd22mK7lP-Tx01gKClONPCMwi8JjHjiQt9AM",
  "userType": 1,
  "createdAt": "2023-07-22T04:17:05.1360458Z"
}
```

### Login

```js
POST /auth/login
```

#### Login Request

```json
{
  "email": "aranab@test.com",
  "password": "aranab1232!"
}
```

#### Login Response

```js
200 OK
```

```json
{
  "id": "be4c2467-e4a2-4d35-8f86-8ac84559fa10",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZTRjMjQ2Ny1lNGEyLTRkMzUtOGY4Ni04YWM4NDU1OWZhMTAiLCJnaXZlbl9uYW1lIjoiTWQuIEFyYWZhdCBSYWhtYW4iLCJmYW1pbHlfbmFtZSI6IlJhbmEiLCJqdGkiOiI1ZGU0NDQwNC0yNzk2LTQ2ODMtYTY5OC01YmJjZjQyODVhY2EiLCJleHAiOjE2OTAwMDMxMDUsImlzcyI6IkVjb21QdWJsaWNBcGkiLCJhdWQiOiJFY29tUHVibGljQXBpIn0.lomKw9_Na06jzaDzkRC1azcBsIzi2xstVtoVnezpLSg",
  "userType": 1,
  "createdAt": "2023-07-22T03:20:32.0891782"
}
```
