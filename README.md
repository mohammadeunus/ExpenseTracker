# Expense Tracker ASP.NET Core Web API Project

This repository contains an Expense Tracker Web API built using ASP.NET Core. The application allows you to track expenses in different categories.

## Prerequisites

Before you start, ensure you have the following installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or above)
- [Git](https://git-scm.com/downloads)
- [MariaDB](https://mariadb.org/download/) or MySQL (Make sure you have the server running and accessible)

## Getting Started

Follow these steps to set up and run the project on your computer:

1. **Clone the Repository**:

   Open a terminal and run the following command to clone this repository:

   ```bash
   git clone git@github.com:mohammadeunus/ExpenseTracker.git
   ```

2. **Navigate to Project Directory**:

   Move to the project directory:

   ```bash
   cd expense-tracker
   ```

3. **Update Connection String**:

   Open the `appsettings.json` file and update the connection string under `"ConnectionStrings"` to match your MariaDB/MySQL server setup.

4. **Build the Application**:

   Run the following command to build the application:

   ```bash
   dotnet build
   ```

5. **Apply Migrations**:

   Apply the database migrations to create the necessary database schema:

   ```bash
   dotnet ef database update
   ```

6. **Run the Application**:

   Start the application:

   ```bash
   dotnet run
   ```

   The application will be accessible at `http://localhost:5000`.

7. **Test the API Endpoints**:

   You can use tools like [Postman](https://www.postman.com/downloads/) or [curl](https://curl.se/download.html) to test the API endpoints:

   - GET: `http://localhost:5000/categories/GetCategories`
   - POST: `http://localhost:5000/categories/AddCategory`

 
8. **Cleanup**:

   Once you're done, you can stop the application by pressing `Ctrl + C` in the terminal.

## Contributions

Feel free to contribute to this project by opening issues or submitting pull requests.

## License

This project is licensed under the [MIT License](LICENSE).
