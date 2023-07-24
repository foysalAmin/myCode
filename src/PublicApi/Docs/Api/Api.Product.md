# Ecom Public API

- [Ecom Public API](#ecom-public-api)
  - [Product](#product)
    - [Create Product](#create-product)
      - [Create Request](#create-request)
      - [Create Response](#create-response)
    - [Get Product by Id](#get-product-by-id)
      - [Get Response](#get-response)
    - [Get All Products](#get-all-products)

## Product

### Create Product

```js
POST /products/create
```

#### Create Request

```json
{
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "price": "1000.00",
}
```

#### Create Response

```js
200 OK
```

```json
{
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "price": "1000.00",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get Product by Id

```js
GET /products/{id}
```

#### Get Response

```js
200 OK
```

```json
{
  "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "name": "Laptop",
  "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
  "price": "1000.00",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get All Products

```js
GET /products
```

#### Get All Products Response

```js
200 OK
```

```json
[
    {
      "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "name": "Apple Laptop",
      "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
      "price": "1000.00",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    {
      "id": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "name": "Windows Laptop",
      "description": "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
      "price": "500.00",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    ...
]
```
