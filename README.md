# RaceDay Part 2 – Event Management API

## 1. Project Overview
RaceDay is an event management system designed for road running, walking, and cycling events. This project uses an ASP.NET Core Web API to manage events, categories, participant enrolments, and race results.

## 2. Technologies Used
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- JWT Authentication
- xUnit Testing
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

## 4. Database
The application uses Microsoft SQL Server and Entity Framework Core to access the RaceDay database.

Update the database connection settings in `appsettings.json` for your own environment before running the application. Do not upload passwords or other secrets.

## 5. Running the Project
1. Open the solution in Visual Studio.
2. Check the database connection settings.
3. Build the solution.
4. Run the RaceDay project.
5. Open the Swagger page to test the API endpoints.

## 6. Testing
The `RaceDay.Tests` project contains automated tests written using xUnit. Run the tests through Test Explorer in Visual Studio.

## 7. Repository Structure
- `RaceDay` – Main Web API project.
- `RaceDay.Tests` – Automated test project.

## 8. Author
Jay Mphaphuli

## 9. Project Purpose
This project demonstrates the development of a secure event management API with database connectivity, role-based access, documentation, and automated testing.
