**Product Management API**

This is a RESTful API built using ASP.NET Core 8, implementing JWT Authentication, Redis Caching, Hangfire for Background Jobs, and Entity Framework Core with SQL Server. The API supports CRUD operations for products and includes user authentication.

**📌 Features**

User Authentication (JWT-based login, update, delete users)

Product Management (CRUD operations on products)

Redis Caching for performance optimization

Hangfire for background job scheduling

API Versioning (v1, v2 support)

Swagger UI for easy API testing

**📂 Project Structure**

📁 ProductManagementAPI
 ┣ 📂 Controllers
 ┃ ┣ 📜 AuthController.cs
 ┃ ┣ 📜 ProductsController.cs
 ┣ 📂 DTOs
 ┃ ┣ 📜 ProductDTO.cs
 ┣ 📂 Helpers
 ┃ ┣ 📜 JwtHelper.cs
 ┣ 📂 Middlewares
 ┃ ┣ 📜 ExceptionMiddleware.cs
 ┣ 📂 Models
 ┃ ┣ 📜 User.cs
 ┃ ┣ 📜 Product.cs
 ┣ 📂 Repositories
 ┃ ┣ 📜 IProductRepository.cs
 ┃ ┣ 📜 ProductRepository.cs
 ┣ 📂 Data
 ┃ ┣ 📜 AppDbContext.cs
 ┣ 📜 Program.cs
 ┣ 📜 appsettings.json
 ┣ 📜 README.md

**🛠️ Installation & Setup**

1️⃣ Clone the repository

git clone [https://github.com/your-repo/ProductManagementAPI.git](https://github.com/Ruchilavichare)
cd ProductManagementAPI

2️⃣ Install dependencies

dotnet restore

3️⃣ Update database connection in appsettings.json

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDB;Trusted_Connection=True;"
},
"RedisConnection": "localhost:6379"

4️⃣ Run database migrations

dotnet ef database update

5️⃣ Run the API

dotnet run

The API will be available at: http://localhost:5000

**🔐 Authentication (JWT Token)**

Login (POST /api/auth/login)

{
  "username": "admin",
  "password": "password"
}

Update User (PUT /api/auth/update/{username})

Delete User (DELETE /api/auth/delete/{username})

**📌 Product API Endpoints**

1️⃣ Get All Products

GET /api/v1/products

2️⃣ Get Product by ID

GET /api/v1/products/{id}

3️⃣ Create Product

POST /api/v1/products

{
  "name": "Laptop",
  "price": 1000.50
}

4️⃣ Update Product

PUT /api/v1/products/{id}

{
  "name": "Updated Laptop",
  "price": 1200.00
}

5️⃣ Delete Product

DELETE /api/v1/products/{id}

**🚀 Additional Features**

Swagger UI: http://localhost:5000/swagger

Hangfire Dashboard: http://localhost:5000/hangfire

Caching: Integrated with Redis
