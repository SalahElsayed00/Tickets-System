# Tickets System

This simple ticket system is implemented using .NET Core and SQL Server.

## Features
- Create tickets with various properties.
- List tickets with pagination.
- Handle tickets.
- Automatic ticket handling after 60 minutes.
- Color coding for ticket age.
  
## Usage
- Create a ticket: Send a POST request to the /api/tickets endpoint with the required information in the request body.
- List tickets: Send a GET request to the /api/tickets endpoint to retrieve a paginated list of tickets.
- Handle tickets: Send a PATCH request to the /api/tickets/{id} endpoint with the ticket ID and status "handled" in the request body.
- Automatic handling: Tickets are automatically marked as handled after 60 minutes by a background job running in the API.
- Automatic handling Ticket Color : Tickets are colored based on their age:
	- Red if created 60 minutes ago or more.
	- Blue if created between 45 and 59 minutes ago.
	- Green if created between 30 and 44 minutes ago.
	- Yellow if created between 15 and 29 minutes ago.
 
## FrameWork
- .NET 6 SDK
- Orm (EF Core)

## Data Store
- SQL Server

## Methodologies
- Clean Arch
- Cqrs
- Repository
- Background job

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/SalahElsayed00/Tickets-System
