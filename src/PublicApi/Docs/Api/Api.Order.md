# Ecom Public API

- [Ecom Public API](#ecom-public-api)
  - [Order](#order)
    - [Create Order](#create-order)
      - [Create Request](#create-request)
      - [Create Response](#create-response)
    - [Get Order by Id](#get-order-by-id)
      - [Get Response](#get-response)
    - [Get All Orders](#get-all-orders)
      - [Get All Orders Response](#get-all-orders-response)

## Order

### Create Order

```js
POST /orders/create
```

#### Create Request

```json
{
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "ProductId": "00000000000-0000-0000-000000000000000",
  "street": "any street",
  "city" : "any city",
  "state" : "any state",
  "country" : "any country",
  "zipcode" : "a11211",
  "qty": "2",
  "unitPrice": "1000.00",
}
```

#### Create Response

```js
200 OK
```

```json
{
  "id" : "00000000000-0000-0000-000000000000000",
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "productId": "00000000000-0000-0000-000000000000000",
  "street": "any street",
  "city" : "any city",
  "state" : "any state",
  "country" : "any country",
  "zipcode" : "a11211",
  "qty": "2",
  "unitPrice": "1000.00",
  "total": "2000.00",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get Order by Id

```js
GET /orders/{id}
```

#### Get Response

```js
200 OK
```

```json
{
  "id" : "00000000000-0000-0000-000000000000000",
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
  "productId": "00000000000-0000-0000-000000000000000",
  "street": "any street",
  "city" : "any city",
  "state" : "any state",
  "country" : "any country",
  "zipcode" : "a11211",
  "qty": "2",
  "unitPrice": "1000.00",
  "total": "2000.00",
  "createAt": "2024-01-01T00:00:00.0000000Z"
}
```

### Get All Orders

```js
GET /orders
```

#### Get All Orders Response

```js
200 OK
```

```json
[
    {
      "id" : "00000000000-0000-0000-000000000000000",
      "paymentRef": "00000000000-0000-0000-000000000000000",
      "customerId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "productId": "00000000000-0000-0000-000000000000000",
      "street": "any street",
      "city" : "any city",
      "state" : "any state",
      "country" : "any country",
      "zipcode" : "a11211",
      "qty": "2",
      "unitPrice": "1000.00",
      "total": "2000.00",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    {
      "id" : "00000000000-0000-0000-000000000000000",
      "paymentRef": "00000000000-0000-0000-000000000000000",
      "customerId": "d89c2cd9a-eb3e-4075-95ff-b920b55aa104",
      "productId": "00000000000-0000-0000-000000000000000",
      "street": "any street",
      "city" : "any city",
      "state" : "any state",
      "country" : "any country",
      "zipcode" : "a11211",
      "qty": "2",
      "unitPrice": "1000.00",
      "total": "2000.00",
      "createAt": "2024-01-01T00:00:00.0000000Z"
    },
    ...
]
```
