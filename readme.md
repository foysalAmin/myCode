# ECom Public Api

This project build on following architectures and principles:

- Domain-Driven Design principles.
- Feature based clean architecture.
- Application request pipleline using CQRS pattern.
- Handling the response and exceptions by applying control flow pattern.
- Gets the configurations using the options pattern.

## Docker container

- Run the docker-compose command from root directory of solution file.

 ```shell
 > docker-compose up -d
 ```

Call the API from any REST Client

- The exposed URI is : [https://localhost:5200](https://localhost:5200)
- Port: 5200

## Endpoints

### [Authentication](./docs/Api/Api.Auth.md)

- User registration : [https://localhost:5200/auth/register](https://localhost:5200/auth/register)
- User login: [https://localhost:5200/auth/login](https://localhost:5200/auth/login)

### [Products](./docs/Api/Api.Product.md)

- Create Product: [https://localhost:5200/products/create](https://localhost:5200/products/create)
- Get specific product: [https://localhost:5200/products/{productId}](https://localhost:5200/products/{productId})
- Get All products: [https://localhost:5200/products](https://localhost:5200/products)

### [Customers](./docs/Api/Api.Customer.md)

- Create customer: [https://localhost:5200/customers/create](https://localhost:5200/customers/create)
- Get specific customer: [https://localhost:5200/customers/{productId}](https://localhost:5200/customers/{customerId})
- Get All customers: [https://localhost:5200/customers](https://localhost:5200/customers)

### [Orders](./docs/Api/Api.Order.md)

- Create order: [https://localhost:5200/orders/create](https://localhost:5200/orders/create)
- Get specific order: [https://localhost:5200/orders/{productId}](https://localhost:5200/orders/{orderId})
- Get All orders: [https://localhost:5200/orders](https://localhost:5200/orders)

#### NOTE: Run all the requests from requests folder of root directory

- Database super user: sa
- password: @root#098@
