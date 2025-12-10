**Employee Management App
This project contains two parts:**

- Employee CRUD API (in-memory)

- User authentication with JWT + simple Razor UI

The solution is built using .NET 8, and everything runs from the same API project.

**Employee CRUD API:**

 - The API includes CRUD operations for an Employee class.

 - Data is stored in memory, and the project starts with 3 sample employees.

 - All endpoints use controllers and return JSON.

- Swagger is enabled to test all operations.

**Endpoints:**

| Method | Endpoint              | Description            |
| ------ | --------------------- | ---------------------- |
| GET    | `/api/employees`      | Returns all employees  |
| GET    | `/api/employees/{id}` | Returns one employee   |
| POST   | `/api/employees`      | Creates a new employee |
| PUT    | `/api/employees/{id}` | Updates an employee    |
| DELETE | `/api/employees/{id}` | Deletes an employee    |

**Login + JWT + Razor Pages**

- This part adds simple authentication:

- A UserApp class is created with username and password.

- Three test users are stored in memory.

- A login endpoint checks credentials and returns a JWT.

- A protected endpoint returns the list of users but only when the JWT is valid.

- A small Razor UI is included:

     - Login page (/Account/Login)
     - Users page (/Account/Users)

The Razor pages call the API internally and store the JWT temporarily.


**Authentication Endpoints**


| Method | Endpoint              | Description            |
| ------ | --------------------- | ---------------------- |
| POST    | `/api/auth/login`      | Returns JWT when credentials are valid  |
| GET    | `/api/users` | Returns users (JWT required)   |


**How to Run**

1- Open the solution in Visual Studio 2022

2- Set EmployeeManagement.Api as the startup project

3- Run the project

**You can access:**

- Swagger: /swagger

- Login page: /Account/Login

 
 **Technologies Used:**

.NET 8

ASP.NET Core Web API

Razor Views

JWT Authentication

In-memory repositories
