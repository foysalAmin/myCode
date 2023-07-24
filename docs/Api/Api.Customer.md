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
  "email": "aranab@cus.com",
  "password": "aranab1232!",
  "address": {
    "phoneNumber": "+123111313",
    "street": "some street",
    "city" : "any city",
    "state": "any state",
    "zipCode": "a11211",
    "country": "any country"
  }
}
```

#### Create Response

```js
200 OK
```

```json
{
  "customerId": "c3724d58-93ee-4b72-8087-14fa6bc9adfe",
  "userId": "4542889e-9cb6-4f60-9fa1-4cc7b6a7c2cd",
  "address": {
    "phoneNumber": "+123111313",
    "street": "some street",
    "city": "any city",
    "state": "any state",
    "zipCode": "a11211",
    "country": "any country"
  },
  "totalOrders": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0NTQyODg5ZS05Y2I2LTRmNjAtOWZhMS00Y2M3YjZhN2MyY2QiLCJnaXZlbl9uYW1lIjoiTWQuIEFyYWZhdCBSYWhtYW4iLCJmYW1pbHlfbmFtZSI6IlJhbmEiLCJqdGkiOiJhOWY5ODAyYi1iZjUzLTQ5YjEtYTk5YS1lMjVjOTUwNzY5MTAiLCJleHAiOjE2OTAwMDMxNjcsImlzcyI6IkVjb21QdWJsaWNBcGkiLCJhdWQiOiJFY29tUHVibGljQXBpIn0.1oSwcnB9mVPgN_woh2KuuDo82Ysi2N1k2O5ZX_328Gw",
  "createdAt": "2023-07-22T04:19:27.8657718Z"
}
```

### Get Customer by Id

```js
GET /customers/{customerId}
Content-Type: application/json
Authorization: bearer {token}
```

#### Get Response

```js
200 OK
```

```json
{
  "customerId": "25cdcd62-ee03-4d10-9999-f3343d16cba9",
  "userId": "c91d7bfd-77eb-4b57-9efd-96eb20aed52f",
  "address": {
    "phoneNumber": "+123111313",
    "street": "some street",
    "city": "any city",
    "state": "any state",
    "zipCode": "a11211",
    "country": "any country"
  },
  "totalOrders": 0,
  "token": null,
  "createdAt": null
}
```

### Get All Customers

```js
GET /customers
Content-Type: application/json
Authorization: bearer {token}
```

#### Get All Customers Response

```js
200 OK
```

```json
[
  {
    "userId": {
      "value": "974663bc-316c-4815-88d6-c2505037cb84"
    },
    "address": {
      "phoneNumber": "+123111313",
      "street": "some street",
      "city": "any city",
      "state": "any state",
      "zipCode": "a11211",
      "country": "any country"
    },
    "user": null,
    "orders": [],
    "id": {
      "value": "9a52508e-391b-4b81-bbb3-07fa0cf73b58"
    }
  },
  {
    "userId": {
      "value": "4542889e-9cb6-4f60-9fa1-4cc7b6a7c2cd"
    },
    "address": {
      "phoneNumber": "+123111313",
      "street": "some street",
      "city": "any city",
      "state": "any state",
      "zipCode": "a11211",
      "country": "any country"
    },
    "user": null,
    "orders": [],
    "id": {
      "value": "c3724d58-93ee-4b72-8087-14fa6bc9adfe"
    }
  },
  {
    "userId": {
      "value": "b181db24-8521-4d16-a13d-a7df2bc23e91"
    },
    "address": {
      "phoneNumber": "+123111313",
      "street": "some street",
      "city": "any city",
      "state": "any state",
      "zipCode": "a11211",
      "country": "any country"
    },
    "user": null,
    "orders": [],
    "id": {
      "value": "c8b6c710-53ed-48ef-9041-9ba09240e146"
    }
  },
  {
    "userId": {
      "value": "c91d7bfd-77eb-4b57-9efd-96eb20aed52f"
    },
    "address": {
      "phoneNumber": "+123111313",
      "street": "some street",
      "city": "any city",
      "state": "any state",
      "zipCode": "a11211",
      "country": "any country"
    },
    "user": null,
    "orders": [],
    "id": {
      "value": "25cdcd62-ee03-4d10-9999-f3343d16cba9"
    }
  }
]
```
