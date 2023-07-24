# Ecom Public API

- [API](#ecom-public-api)
  - [Auth](#auth)
    - [Registration](#registration)
      - [Register Request](#registration-request)
      - [Register Response](#registration-response)
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
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "token": "eyJhb..z9dqcnXoY"
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
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "token": "eyJhb..z9dqcnXoY"
}
```
