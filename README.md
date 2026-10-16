# RaceDay Part 2 – Event Management API

## 1. Project Overview

RaceDay is an event management system for road running, walking, and cycling events. It uses an ASP.NET Core Web API to manage events, categories, participant enrolments, and race results.

The system allows organisers to manage events and results while participants can register and enrol in event categories.

## 2. Project Objectives

The main objectives of the RaceDay project are to:

- Develop an API for managing sporting events.
- Allow users to register and log in securely.
- Give organisers and participants different access permissions.
- Manage events, categories, enrolments, and results.
- Store and retrieve information using Microsoft SQL Server.
- Test the system using automated unit tests.
- Use GitHub Actions to build the project and run tests automatically.

## 3. Technologies Used

The project uses the following technologies:

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

The main features of the system include:

- User registration and login.
- Password hashing.
- JWT authentication.
- Role-based access for Organisers and Participants.
- Event management.
- Category management.
- Participant enrolments.
- Race results management.
- Database connectivity using Entity Framework Core.
- API documentation and testing through Swagger.
- Automated unit tests.
- Automated builds and tests using GitHub Actions.

## 5. API Endpoints

The following table lists the main API endpoints.

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
| GET | `/api/enrolments` | View all enrolments |
| GET | `/api/enrolments/my` | View your enrolments |
| POST | `/api/enrolments` | Enrol in a category |
| GET | `/api/results` | View race results |
| GET | `/api/results/my` | View your own results |
| POST | `/api/results` | Record a race result |

Some endpoints require authentication and specific roles. Organisers and Participants have different permissions.

For more information about endpoint methods, access requirements, inputs, and responses, see `API_Endpoint_Plan.md`.

*Note: The endpoint list should match the routes actually implemented in the application.*

## 6. Database

The application uses Microsoft SQL Server to store information about users, events, categories, enrolments, and race results.

Entity Framework Core is used to communicate with the database.

Before running the project:

1. Make sure Microsoft SQL Server is installed and running.
2. Create or restore the RaceDay database using the database script or setup method provided for the project.
3. Check the connection string in `appsettings.json`.
4. Update the connection string to
