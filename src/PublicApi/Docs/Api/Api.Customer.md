# Ecom Public API

- [Ecom Public API](#ecom-public-api)
  - [customer](#customer)
    - [Create Customer](#create-customer)
      - [Create Request](#create-request)
      - [Create Response](#create-response)
    - [Get Customer by Id](#get-customer-by-id)
      - [Get Response](#get-response)
    - [Get All Customers](#get-all-customers)
      - [Get All Customers Response](#get-all-customers-response)

## customer

### Create Customer

```js
POST /customers/create
```

#### Create Request

```json
{
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "phoneNumber": "+123111313",
  "address1": "some street, any location, any state, country",
  "address2": "different street, any location, any state, country",
  "zipcode": "a11211",
  "password": "aranab1232!",
}
```

#### Create Response

```js
200 OK
```

```json
{
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "phoneNumber": "+123111313",
  "address1": "some street, any location, any state, country",
  "address2": "different street, any location, any state, country",
  "zipcode": "a11211",
  "userId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get Customer by Id

```js
GET /customers/{id}
```

#### Get Response

```js
200 OK
```

```json
{
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "firstName": "Md. Arafat Rahman",
  "lastName": "Rana",
  "email": "aranab@test.com",
  "phoneNumber": "+123111313",
  "address1": "some street, any location, any state, country",
  "address2": "different street, any location, any state, country",
  "zipcode": "a11211",
  "userId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get All Customers

```js
GET /customers
```

#### Get All Customers Response

```js
200 OK
```

```json
[
    {
      "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "firstName": "Md. Arafat Rahman",
      "lastName": "Rana",
      "email": "aranab@test.com",
      "phoneNumber": "+123111313",
      "address1": "some street, any location, any state, country",
      "address2": "different street, any location, any state, country",
      "zipcode": "a11211",
      "userId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    {
      "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "firstName": "Md. Arafat Rahman",
      "lastName": "Rana",
      "email": "aranab@test.com",
      "phoneNumber": "+123111313",
      "address1": "some street, any location, any state, country",
      "address2": "different street, any location, any state, country",
      "zipcode": "a11211",
      "userId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    ...
]
```
