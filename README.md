Explanation
How the Code Works
1.	Program.cs:
•	This is the entry point of the application.
•	It sets up the base directory and constructs the connection string for the SQLite database.
•	It configures the services required by the application, including the database context, repositories, and services.
•	It configures middleware for handling HTTP requests, serving static files, and setting up Swagger for API documentation.
•	Finally, it runs the application.
2.	PersonDetailsControllerTests.cs:
•	This file contains integration tests for the PersonDetailsController.
•	It uses WebApplicationFactory<Program> to create a test server and an HttpClient to send HTTP requests to the application.
•	It contains several test methods to verify the behavior of the PersonDetailsController endpoints.
3.	DataLayer.csproj:
•	This project file defines the DataLayer project.
•	It includes references to necessary packages such as Microsoft.EntityFrameworkCore and Microsoft.Data.Sqlite.
•	It specifies that certain files should be copied to the output directory.
4.	MoaazSalemTask.Tests.csproj:
•	This project file defines the test project.
•	It includes references to necessary packages such as xunit and Microsoft.AspNetCore.Mvc.Testing.
•	It includes a target to copy the testhost.deps.json file to the output directory.
Design Patterns and Architecture
•	Repository Pattern: The Repository<T> class implements the IRepository<T> interface, providing a generic way to interact with the database.
•	Service Layer: The PersonDetailsService class implements the IPersonDetailsService interface, providing business logic for handling person details.
•	Dependency Injection: Services and repositories are registered in the Program.cs file and injected into controllers and other services as needed.
•	MVC Architecture: The application follows the Model-View-Controller (MVC) architecture, with models defined in the DataLayer, controllers handling HTTP requests, and views served as static files.
README
# MoaazSalemTask

This is a .NET 8 application that provides an API for managing person details. It uses SQLite as the database and includes integration tests.

## How to Run the Application

1. **Clone the Repository**:
   git clone  cd MoaazSalemTask
   
3. **Build the Solution**:
   Open the solution in Visual Studio 2022 and build it.

4. **Run the Application**:
   Press `F5` or use the `dotnet run` command in the terminal:
   dotnet run --project MoaazSalemTask

5. **Run the Swagger API**:
http://localhost/swagger/index.html
GET
/PersonDetails
click on "Try it out" then "Execute"


6. **Run the HTML Page**:

open http://localhost/html/persondetails.html



## How to Run the Tests

1. **Navigate to the Test Project Directory**:
   cd MoaazSalemTask.Tests

   
2. **Run the Tests**:
   Use the `dotnet test` command to run the tests:


   
## API Endpoint

### Get Person Details

- **Endpoint**: `/PersonDetails`
- **Method**: `GET`
- **Parameters**:
  - `Name` (string): The name of the person.
  - `TelephoneNumber` (string): The telephone number of the person.
- **Response**: Returns the details of the person if found.

### Example Call
curl -X GET "https://localhost/PersonDetails?Name=rana&TelephoneNumber=4444"





## Design Patterns and Architecture

- **Repository Pattern**: Used to abstract data access logic.
- **Service Layer**: Encapsulates business logic.
- **Dependency Injection**: Used to inject dependencies into controllers and services.
- **MVC Architecture**: The application follows the Model-View-Controller architecture.

### Project Structure

- **MoaazSalemTask**: Main application project.
- **DataLayer**: Contains models and database context.
- **MoaazSalemTask.Tests**: Contains integration tests.

### Dependencies

- `Microsoft.EntityFrameworkCore`
- `Microsoft.Data.Sqlite`
- `CsvHelper`
- `xunit`
- `Microsoft.AspNetCore.Mvc.Testing`

