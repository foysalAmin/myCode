# Ecom Public API

- [Ecom Public API](#ecom-public-api)
  - [Product](#product)
    - [Create Product](#create-product)
      - [Create Request](#create-request)
      - [Create Response](#create-response)
    - [Get Product by Id](#get-product-by-id)
      - [Get Response](#get-response)
    - [Get All Products](#get-all-products)
      - [Get All Products Response](#get-all-products-response)

## Product

### Create Product

```js
POST /products/create
Content-Type: application/json
Authorization: bearer {{token}}

```

#### Create Request

```json
{
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "currency": "USD",
  "price": "1000.00"
}
```

#### Create Response

```js
200 OK
```

```json
{
  "id": {
    "value": "1c383bcd-09f0-44bf-992f-d3ed39bada9e"
  }
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "price": {
    "currency": "USD",
    "amount": 1000.00
  },
  "createdAt": "2023-07-22T05:15:15.9697767Z",
}
```

### Get Product by Id

```js
GET /products/{id}
Content-Type: application/json
Authorization: bearer {{token}}

```

#### Get Response

```js
200 OK
```

```json
{
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "price": {
    "currency": "USD",
    "amount": 1000.00
  },
  "createdAt": "2023-07-22T05:15:15.9697767",
  "id": {
    "value": "1c383bcd-09f0-44bf-992f-d3ed39bada9e"
  }
}
```

### Get All Products

```js
GET /products
Content-Type: application/json
Authorization: bearer {token}
```

#### Get All Products Response

```js
200 OK
```

```json
[
  {
    "name": "Laptop",
    "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
    "price": {
      "currency": "USD",
      "amount": 1000.00
    },
    "createdAt": "2023-07-22T05:15:15.9697767",
    "id": {
      "value": "1c383bcd-09f0-44bf-992f-d3ed39bada9e"
    }
  },
  {
    "name": "Computer",
    "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
    "price": {
      "currency": "USD",
      "amount": 500.00
    },
    "createdAt": "2023-07-22T06:12:59.0339979",
    "id": {
      "value": "04afa52e-7459-4e5a-9593-dec01eb5ef68"
    }
  },
  ...
]
```
