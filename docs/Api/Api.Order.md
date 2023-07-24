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
POST  /orders/create
Content-Type: application/json
Authorization: bearer {token}
```

#### Create Request

```json
{
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
  "Email": "azmat@cust.com",
  "shipToAddress": {
    "phoneNumber": "+11111154445",
    "street": "any street",
    "city" : "any city",
    "state" : "any state",
    "country" : "any country",
    "zipCode" : "a11211"
  },
  "Items": [
    {
      "productId": "1c383bcd-09f0-44bf-992f-d3ed39bada9e",
      "currency": "USD",
      "amount": "1000.00",
      "qty": "2"
    }
  ]
}
```

#### Create Response

```js
200 OK
```

```json
{
  "orderId": "4ab0e359-ad20-43f2-8fa7-dc0fb71ab39d",
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
  "email": "azmat@cust.com",
  "shipToAddress": {
    "phoneNumber": "+11111154445",
    "street": "any street",
    "city": "any city",
    "state": "any state",
    "country": "a11211",
    "zipCode": "any country"
  },
  "items": [
    {
      "itemId": "499d5108-93de-4de0-9572-082723f800ad",
      "productId": "1c383bcd-09f0-44bf-992f-d3ed39bada9e",
      "currency": "USD",
      "amount": 1000.00,
      "qty": 2
    }
  ],
  "total": "$2,000.00",
  "createdAt": "2023-07-22T08:41:59.6118757Z"
}
```

### Get Order by Id

```js
GET  /orders/{id}
Content-Type: application/json
Authorization: bearer {token}
```

#### Get Response

```js
200 OK
```

```json
{
  "orderId": "4ab0e359-ad20-43f2-8fa7-dc0fb71ab39d",
  "paymentRef": "00000000000-0000-0000-000000000000000",
  "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
  "email": "azmat@cust.com",
  "shipToAddress": {
    "phoneNumber": "+11111154445",
    "street": "any street",
    "city": "any city",
    "state": "any state",
    "country": "a11211",
    "zipCode": "any country"
  },
  "items": [
    {
      "itemId": "499d5108-93de-4de0-9572-082723f800ad",
      "productId": "1c383bcd-09f0-44bf-992f-d3ed39bada9e",
      "currency": "USD",
      "amount": 1000.00,
      "qty": 2
    }
  ],
  "total": "$2,000.00",
  "createdAt": "2023-07-22T08:41:59.6118757"
}
```

### Get All Orders

```js
GET  /orders
Content-Type: application/json
Authorization: bearer {token}
```

#### Get All Orders Response

```js
200 OK
```

```json
[
  {
    "orderId": "06c05ad6-66ee-42b1-9c3c-4e950e1bc68d",
    "paymentRef": "00000000000-0000-0000-000000000000000",
    "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
    "email": "azmat@cust.com",
    "shipToAddress": {
      "phoneNumber": "+11111154445",
      "street": "any street",
      "city": "any city",
      "state": "any state",
      "country": "a11211",
      "zipCode": "any country"
    },
    "items": [
      {
        "itemId": "01494e2d-b91f-4787-8f72-cf1ae2e434ca",
        "productId": "1c383bcd-09f0-44bf-992f-d3ed39bada9e",
        "currency": "USD",
        "amount": 1000.00,
        "qty": 2
      }
    ],
    "total": "$2,000.00",
    "createdAt": "2023-07-22T07:46:41.9287315"
  },
  {
    "orderId": "d46689f8-257b-43b2-8476-63cbb46ec3cb",
    "paymentRef": "00000000000-0000-0000-000000000000000",
    "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
    "email": "azmat@cust.com",
    "shipToAddress": {
      "phoneNumber": "+11111154445",
      "street": "any street",
      "city": "any city",
      "state": "any state",
      "country": "a11211",
      "zipCode": "any country"
    },
    "items": [
      {
        "itemId": "0dcdc7d0-30b2-48b2-be42-d71e64560606",
        "productId": "1c383bcd-09f0-44bf-992f-d3ed39bada9e",
        "currency": "USD",
        "amount": 1000.00,
        "qty": 2
      }
    ],
    "total": "$2,000.00",
    "createdAt": "2023-07-22T08:08:10.8173693"
  },
  ...
]
```
