# Tickets System

This simple ticket system is implemented using .NET Core and SQL Server.

## Features

- Create a ticket: Navigate to the Create Ticket page and fill in the required information.
- List tickets: View a paginated list of tickets with various properties.
- Handle tickets: Click the handle button to mark a ticket as handled.
- Automatic handling: Tickets are automatically marked as handled after 60 minutes.
- Color coding: Tickets are colored based on their age:
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
