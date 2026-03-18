# SafeWildlife Love4Animals Application Backend

This is a non-profit application for wildlife conservation and care. It's a backend built with .NET Core, focusing on scalability and a clean architecture.

---

## 🏗️ Architecture

This projelsct follows an N-Tier architecture pattern:

* **API / Controllers Layer:** Entry point for HTTP requests. Handles request validation and response formatting.
* **Business Logic Layer (Services):** Contains all the business rules and logic of the application.
* **Data Access Layer (Repositories):** Manages the communication with the database (using Entity Framework Core).
* **Data Transfer Objects (DTOs):** Used to decouple the API from internal models and transfer only necessary data.

## 💾 Prerequisites

Before running this project, you will need:

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher is recommended)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or your preferred database engine)

## 🚀 Getting Started

1.  **Clone the repository:**
    ```bash
    git clone [repository-url]
    cd love4animals-backend
    ```

2.  **Configure the database connection:**
    Update the `ConnectionStrings` section in the `appsettings.json` file with your SQL Server connection details.

3.  **Run Database Migrations:**
    ```bash
    dotnet ef database update
    ```

4.  **Run the application:**
    ```bash
    dotnet run
    ```

## 💉 Dependency Injection Lifetimes

This project registers services using the following lifetimes:

* **Transient:** For stateless, lightweight services (e.g., small data validation logic).
* **Scoped:** Used for database contexts (`DbContext`) and repositories, ensuring a single instance per HTTP request.
* **Singleton:** Used for services that maintain global state or cache configuration (e.g., configuration managers).

---

## 📄 License

This project is open-source and intended for non-profit use.

For more information, feel free to contact the project maintainers.