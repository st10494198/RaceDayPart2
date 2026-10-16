# RaceDay Part 2 – Event Management API

## 1. Project Overview

RaceDay is an event management system for road running, walking, and cycling events. It uses an ASP.NET Core Web API to manage events, categories, participant enrolments, and race results.

The system allows organisers to manage events and results while participants can register, log in, and enrol in event categories.

## 2. Project Objectives

The main objectives are to:

- Develop an API for managing sporting events.
- Allow users to register and log in securely.
- Give organisers and participants different access permissions.
- Manage events, categories, enrolments, and results.
- Store information using Microsoft SQL Server.
- Test the system using automated unit tests.
- Use GitHub Actions to build the project and run tests automatically.

## 3. Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- Microsoft SQL Server
- Swagger / OpenAPI
- JWT Authentication
- xUnit Testing
- Visual Studio
- GitHub and GitHub Actions

## 4. Main Features

- User registration and login.
- Password hashing.
- JWT authentication and role-based authorization.
- Event management.
- Category management.
- Participant enrolments.
- Race results management.
- Database connectivity using Entity Framework Core.
- API documentation and testing through Swagger.
- Automated unit tests.
- Automated builds and tests using GitHub Actions.
- Server-side session storage for the logged-in user's ID and role.

## 5. API Endpoints

| Method | Endpoint | Purpose |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Log in and receive a token |
| GET | `/api/events` | View all events |
| GET | `/api/events/{id}` | View one event |
| POST | `/api/events` | Create an event |
| PUT | `/api/events/{id}` | Update an event |
| DELETE | `/api/events/{id}` | Delete an event |
| GET | `/api/categories` | View all categories |
| GET | `/api/categories/{id}` | View one category |
| POST | `/api/categories` | Create a category |
| PUT | `/api/categories/{id}` | Update a category |
| DELETE | `/api/categories/{id}` | Delete a category |
| GET | `/api/enrolments` | View all enrolments (Organiser) |
| GET | `/api/enrolments/my` | View your enrolments |
| POST | `/api/enrolments` | Enrol in a category |
| GET | `/api/results` | View race results (Organiser) |
| GET | `/api/results/my` | View your own results |
| POST | `/api/results` | Record a race result (Organiser) |

Some endpoints require authentication and specific roles. See `API_Endpoint_Plan.md` for further endpoint details.

## 6. Database Setup

The application uses Microsoft SQL Server to store users, events, categories, enrolments, and race results. Entity Framework Core is used to communicate with the database.

Before running the project:

1. Install and start Microsoft SQL Server.
2. Open SQL Server Management Studio (SSMS).
3. Create or restore the RaceDay database using the database script provided with the project.
4. Open `appsettings.json`.
5. Update the `RaceDayConnection` connection string to match your SQL Server instance.
6. Save the changes and confirm that the application can connect to the database.

Do not upload database passwords or other private connection details to GitHub.

## 7. How to Run the API

1. Open the RaceDay solution in Visual Studio.
2. Confirm that the database connection string is correct.
3. Restore the NuGet packages if required.
4. Build the solution.
5. Run the RaceDay API project.
6. Open the Swagger URL displayed by the application.
7. Use Swagger to register users, log in, authorize requests, and test the endpoints.

## 8. Authentication and Authorization

The API supports registration and login for Organisers and Participants.

Passwords are hashed before being stored in the database. After successful login, the API issues a JWT containing the user's identity and role.

Role-based authorization restricts access to protected endpoints. Server-side session storage is also configured to store the logged-in user's ID and role.

## 9. Unit Testing

The project uses xUnit to test application functionality and selected authentication and authorization behaviour.

Run the tests in Visual Studio:

1. Open **Test Explorer**.
2. Select **Run All**.
3. Check the number of passed and failed tests.

## 10. Continuous Integration and Deployment (CI/CD)

GitHub Actions is used to build the project and run automated tests whenever the configured workflow is triggered.

**Build and test evidence:**  
Insert a screenshot of the successful GitHub Actions workflow here.

## 11. Project Files

The repository contains the RaceDay API source code, test project, database-related files, API endpoint plan, and project documentation.

Check the repository for the exact filenames and instructions supplied with the project.

## 12. Video Presentation

The video presentation demonstrates the API, authentication, role-based access, Swagger testing, database functionality, unit tests, and GitHub Actions workflow.

**Video link:** [Insert your video presentation link here]

## 13. Conclusion

The RaceDay project provides an API for managing sporting events, participant enrolments, and race results. It uses SQL Server for data storage, JWT for authentication, role-based authorization for access control, and automated testing through GitHub Actions.
