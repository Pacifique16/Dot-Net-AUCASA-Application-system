# AUCA Student Application System (AUCASAPRO_26937)

## Overview
A Windows Forms application for managing student applications for positions at AUCA. The system allows administrators to create positions, students to apply, and admins to approve/reject applications.

## Features

### 1. Position Management (Admin)
- Create new positions with title and description
- Update existing positions
- Delete positions
- View all positions in a grid

### 2. Student Application Interface
- Submit applications with student details (ID, name, department, semester, average, position)
- Check application status by student ID
- Update existing applications
- Cancel applications
- View all applications in a grid

### 3. Approve/Reject Interface (Admin)
- View all pending applications
- Approve applications
- Reject applications
- View application details

## Database Setup

1. Run the `DatabaseScript.sql` file in SQL Server Management Studio to create:
   - Database: AUCASADB_26937
   - Tables: Positions, Applications

2. Update the connection string in `App.config` if needed:
   ```xml
   Data Source=YOUR_SERVER\\SQLEXPRESS;Initial Catalog=AUCASADB_26937;Integrated Security=True;TrustServerCertificate=True
   ```

## Database Schema

### Positions Table
- PositionID (INT, Primary Key, Identity)
- PositionTitle (NVARCHAR(100))
- PositionDescription (NVARCHAR(500))

### Applications Table
- ApplicationID (INT, Primary Key, Identity)
- StudentID (NVARCHAR(50))
- StudentName (NVARCHAR(100))
- Department (NVARCHAR(100))
- Semester (INT)
- CurrentAverage (DECIMAL(5,2))
- PositionID (INT, Foreign Key)
- Status (NVARCHAR(20), Default: 'Pending')

## How to Use

1. **Start the Application**: Run the program to see the Main Menu
2. **Position Management**: Click to create/update/delete positions
3. **Student Application**: Click to submit or manage applications
4. **Approve/Reject**: Click to review and approve/reject pending applications

## Technical Details
- Framework: .NET 10.0 Windows Forms
- Database: SQL Server
- Data Access: ADO.NET (System.Data.SqlClient)
- Configuration: App.config with connection strings

## Student ID: 26937
