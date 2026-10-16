# RaceDay Part 2 – API Endpoint Plan

## 1. Introduction
The RaceDay API manages running, walking, and cycling events. It allows organisers to manage events and results, while participants can register, log in, browse events, and view their enrolments and results.

## 2. Authentication

| Method | Endpoint | Purpose | Access |
|---|---|---|---|
| POST | `/api/auth/register` | Register a new user | Public |
| POST | `/api/auth/login` | Log in and receive a JWT token | Public |

Protected endpoints require a valid JWT token in the Authorization header.

## 3. Events

| Method | Endpoint | Purpose | Access |
|---|---|---|---|
| GET | `/api/events` | View events | Based on controller configuration |
| POST | `/api/events` | Create an event | Organiser |
| GET | `/api/events/{id}` | View an event by ID, if supported | Check controller |
| PUT | `/api/events/{id}` | Update an event, if supported | Check controller |
| DELETE | `/api/events/{id}` | Delete an event, if supported | Check controller |

## 4. Categories

| Method | Endpoint | Purpose | Access |
|---|---|---|---|
| GET | `/api/categories` | View categories | Based on controller configuration |
| POST | `/api/categories` | Create a category | Organiser |

## 5. Enrolments

| Method | Endpoint | Purpose | Access |
|---|---|---|---|
| GET | `/api/enrolments` | View enrolments, if supported | Check controller |
| POST | `/api/enrolments` | Enrol a participant, if supported | Check controller |

## 6. Results

| Method | Endpoint | Purpose | Access |
|---|---|---|---|
| GET | `/api/results` | View all race results | Organiser |
| GET | `/api/results/my` | View the logged-in participant's results | Participant |
| POST | `/api/results` | Record a race result | Organiser |

## 7. Security
- Passwords are hashed before they are stored.
- JWT tokens are used to authenticate users.
- Role-based authorisation restricts protected endpoints.
- Organiser-only actions cannot be performed by participants.

## 8. Testing
The `RaceDay.Tests` project contains automated unit tests. GitHub Actions builds the solution and runs the tests when changes are pushed to the configured branches.

## 9. API Documentation
Swagger provides an interactive page for viewing and testing the available API endpoints.

**Note:** Confirm each endpoint and access rule against the actual controller code before submission.
