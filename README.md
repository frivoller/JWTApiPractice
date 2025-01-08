# JWT Authentication System 🔐

## 🚀 Project Overview
This project provides a step-by-step guide to implementing a secure JWT (JSON Web Token) authentication system using C# and Entity Framework. It covers user model creation, database configuration, JWT generation, and token validation.


## 🌟 Features
- **User Model Creation**: A simple User class with essential properties.
- **Database Integration**: Configuration with Entity Framework and DbContext.
- **JWT Generation**: Generate tokens for authenticated users.
- **JWT Validation**: Secure APIs using token-based authorization.

## 🧑‍💻 Usage

### User Model Creation
Define a `User` class with the following properties:

```csharp
public class User {
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
Database Setup
Create a DbContext class and register the User model:

csharp

Copy
public class AppDbContext : DbContext {
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
JWT Generation
In the AuthController, add a Login method to handle user authentication:

csharp

Copy
[HttpPost("login")]
public IActionResult Login([FromBody] LoginRequest request) {
    // Validate user credentials
    // Generate and return JWT
}
JWT Validation
Configure JWT validation in Startup.cs:

csharp

Copy
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"))
        };
    });

