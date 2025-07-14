# Restaurant Table Booking App API

## Overview

This project is a RESTful API for managing restaurant table bookings. It allows users to view restaurants, branches, available dining tables, and make reservations. The API is built with ASP.NET Core and follows a clean architecture with separate layers for API, Service, Data, and Core models.

## Features

- View list of restaurants
- View branches of a restaurant
- View available dining tables and time slots
- Make and manage reservations
- Logging and telemetry with Serilog and Application Insights
- API documentation with Swagger

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (for data storage)
- Serilog (logging)
- Application Insights (telemetry)
- Swagger (API documentation)

## Project Structure

- `RestaurantTableBookingApp.API/` - API layer (controllers, middleware, startup)
- `LSC.RestaurantTableBookingApp.Service/` - Business logic and services
- `LSC.RestaurantTableBookingApp.Data/` - Data access and repositories
- `LSC.RestaurantTableBookingApp.Core/` - Core models and view models

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server instance

### Setup

1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd Restaurant-Table-Booking-App-Api
   ```
2. Update the connection string in `RestaurantTableBookingApp.API/appsettings.json` to point to your SQL Server database.
3. Apply database migrations (if any):
   ```bash
   dotnet ef database update --project LSC.RestaurantTableBookingApp.Data
   ```
4. Run the API:
   ```bash
   dotnet run --project RestaurantTableBookingApp.API
   ```
5. Open Swagger UI at `https://localhost:<port>/swagger` to explore the API endpoints.

## API Endpoints

### Get all restaurants

- `GET /api/restaurant/restaurants`
- Returns a list of restaurants.

### Get branches by restaurant

- `GET /api/restaurant/branches/{restaurantId}`
- Returns branches for a specific restaurant.

### Get dining tables by branch

- `GET /api/restaurant/diningtables/{branchId}`
- Returns available dining tables for a branch.

### Get dining tables by branch and date

- `GET /api/restaurant/diningtables/{branchId}/{date}`
- Returns available dining tables for a branch on a specific date.

## Data Models

- **RestaurantModel**: Id, Name, Address, Phone, Email, ImageUrl
- **RestaurantBranchModel**: Id, RestaurantId, Name, Address, Phone, Email, ImageUrl
- **DiningTableWithTimeSlotsModel**: BranchId, ReservationDay, TableName, Capacity, MealType, TableStatus, TimeSlotId, UserEmailId
- **ReservationModel**: UserId, FirstName, LastName, EmailId, PhoneNumber, TimeSlotId, ReservationDate, ReservationStatus

## Logging & Telemetry

- Logging is handled by Serilog.
- Application Insights is used for telemetry and monitoring.

## License

This project is for educational/demo purposes. Please update with your license as needed.
