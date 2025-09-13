# 🖥️ ASP.NET Core Web Application - Electronics Shop

This project is a **web application** built with **ASP.NET Core MVC** and **Identity** for authentication and authorization.  
It simulates a simple Electronics Shop where:
- Users can register and log in.
- Admins can manage products (create, edit, delete).
- Normal users can only view items.

---

## 🚀 Features
- User registration and login with **ASP.NET Core Identity**.
- Role-based authorization (**Admin** vs normal user).
- Admin features:
  - Add new electronics
  - Edit existing items
  - Delete items
- User features:
  - Browse and view electronics
- Database with **Entity Framework Core** and **SQL Server**.
- Responsive UI styled with **Bootstrap** and **Bootswatch theme**.

---

## 📂 Project Structure

WebAppWithLogin/
│-- Controllers/ # Controllers (ElectronicsController, HomeController)
│-- Models/ # Models (Electronics, ApplicationDbContext)
│-- Views/ # Razor views (UI)
│-- Data/ # DbContext and EF Core Migrations
│-- wwwroot/ # Static files (CSS, JS, Bootstrap)
│-- Program.cs # Entry point of the application
│-- appsettings.json # Database connection settings
│-- WebAppWithLogin.csproj



---

## ⚙️ Requirements
- Visual Studio 2022 or later
- .NET 6.0 SDK or later
- SQL Server (LocalDB, Express, or full)

---

## ▶️ How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR-USERNAME/ASP.NET-Core-WebApplication-Task.git
   cd ASP.NET-Core-WebApplication-Task
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=WebAppWithLogin;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
run database migration :  add-migration  then update-database
