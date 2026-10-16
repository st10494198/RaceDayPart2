
# RaceDay Part 2 – Event Management API

## 1. Project Overview
RaceDay is an event management system for road running, walking, and cycling events. It uses an ASP.NET Core Web API to manage events, categories, participant enrolments, and race results.

## 2. Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core
- Microsoft SQL Server
- Swagger
- JWT Authentication
- xUnit Testing
- GitHub Actions
- Visual Studio

## 3. Main Features
- User registration and login
- Password hashing
- JWT authentication
- Role-based access for Organisers and Participants
- Event and category management
- Participant enrolments
- Race results management
- API documentation through Swagger
- Automated unit tests
- Automated build and test checks through GitHub Actions

## 4. API Endpoints

| Method | Endpoint | Purpose |
|---|---|---|
| GET | /api/events | View events |
| GET | /api/events/{id} | View one event |
| POST | /api/events | Create an event |
| PUT | /api/events/{id} | Update an event |
| DELETE | /api/events/{id} | Delete an event |
| GET | /api/categories | View categories |
| GET | /api/categories/{id} | View one category |
| POST | /api/categories | Create a category |
| PUT | /api/categories/{id} | Update a category |
| DELETE | /api/categories/{id} | Delete a category |
| GET | /api/enrolments | View all enrolments |
| GET | /api/enrolments/my | View your enrolments |
| POST | /api/enrolments | Register for a category |
| GET | /api/results | View race results |
| GET | /api/results/my | View your results |
| POST | /api/results | Record a race result |

Organiser-only and Participant-only permissions apply to the relevant endpoints. See `API_Endpoint_Plan.md` for more details.

## 5. Database
The application uses Microsoft SQL Server and Entity Framework Core to access the RaceDay database.

Update the database connection settings in `appsettings.json` for your own environment before running the application. Never upload passwords, private keys, or other secrets.

## 6. Running the Project
1. Open `RaceDay.sln` in Visual Studio.
2. Check the database connection settings.
3. Make sure SQL Server is running and the RaceDay database is available.
4. Build the solution.
5. Run the RaceDay project.
6. Open the Swagger page to test the API endpoints.

## 7. Testing
The `RaceDay.Tests` project contains automated tests written using xUnit.

To run the tests:
1. Open the solution in Visual Studio.
2. Open Test Explorer.
3. Run all tests.
4. Check that the tests pass.

GitHub Actions also builds the solution and runs the automated tests when changes are pushed to the repository.

## 8. Repository Structure
- `RaceDay` – Main Web API project.
- `RaceDay.Tests` – Automated test project.
- `RaceDay.sln` – Visual Studio solution.
- `API_Endpoint_Plan.md` – API endpoint documentation.
- `.github/workflows` – Automated build and test workflow.

## 9. Author
Jay Mphaphuli

## 10. Project Purpose
This project demonstrates the development of an event management API with database connectivity, authentication, role-based access, documentation, and automated testing.
