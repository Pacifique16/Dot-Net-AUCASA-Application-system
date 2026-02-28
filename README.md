# AUCA Student Application System (AUCASAPRO_26937)

A comprehensive Windows Forms application for managing student applications for positions at AUCA (Adventist University of Central Africa).

## 🎯 Overview

This system provides a complete solution for managing student job applications with four main interfaces:
- **Admin Panel**: Position management (Create, Update, Delete)
- **Student Portal**: Application submission and tracking
- **Approval System**: Admin review and decision-making
- **Statistics Dashboard**: Real-time analytics and insights

## ✨ Features

### 1. Position Management (Admin)
- ✅ Create new positions with title and description
- ✅ Update existing positions
- ✅ Delete positions (with cascade delete for related applications)
- ✅ View all positions in a data grid
- ✅ Click-to-select functionality for easy editing

### 2. Student Application Interface
- ✅ Submit applications with comprehensive student details
- ✅ Email validation (proper format required)
- ✅ Department selection via dropdown (Software Engineering, Information Management, Marketing, Networks and Communication)
- ✅ Position selection via dropdown
- ✅ Check application status by email
- ✅ Update existing applications
- ✅ Cancel applications with confirmation
- ✅ View all applications in a grid
- ✅ **Validation Rules**:
  - Students must be in semester 4 or above
  - Minimum average score of 15 required
  - Cannot apply twice to the same position
  - All fields are required
  - Valid email format required

### 3. Approve/Reject Interface (Admin)
- ✅ View all pending applications
- ✅ Approve applications with confirmation dialog
- ✅ Reject applications with confirmation dialog
- ✅ Read-only fields for data integrity
- ✅ Automatic refresh after approval/rejection

### 4. Statistics Dashboard
- ✅ Real-time application statistics
- ✅ Total applications count
- ✅ Pending, approved, and rejected counts
- ✅ Total positions available
- ✅ Applications breakdown by department
- ✅ Applications breakdown by position
- ✅ Color-coded statistics panels
- ✅ Interactive data grids

## 🛠️ Technical Stack

- **Framework**: .NET 10.0 Windows Forms
- **Database**: SQL Server (AUCASADB_26937)
- **Data Access**: ADO.NET (System.Data.SqlClient)
- **Configuration**: App.config with connection strings
- **Architecture**: Three-tier (Presentation, Business Logic, Data Access)

## 📊 Database Schema

### POSITIONS Table
```sql
- position_id (INT, Primary Key, Identity)
- position_title (NVARCHAR(50))
- position_description (NVARCHAR(60))
```

### CANDIDATES Table
```sql
- student_id (INT, Primary Key, Identity)
- email (NVARCHAR(50))
- fullname (NVARCHAR(50))
- department (NVARCHAR(50))
- semester (NVARCHAR(50))
- current_avg_score (NVARCHAR(50))
- position (INT, Foreign Key → POSITIONS.position_id)
- description (NVARCHAR(50)) [Status: Pending/Approved/Rejected]
```

**Foreign Key Constraint**: CASCADE DELETE enabled - deleting a position automatically removes all related applications.

## 🚀 Installation & Setup

### Prerequisites
- Windows OS
- .NET 10.0 SDK or later
- SQL Server (Express or higher)
- Visual Studio 2022 or later (recommended)

### Database Setup

1. Open SQL Server Management Studio (SSMS)
2. Run the `DatabaseScript.sql` file to create:
   - Database: AUCASADB_26937
   - Tables: POSITIONS, CANDIDATES
   - Foreign key relationships

3. Update the connection string in `App.config` if needed:
```xml
<connectionStrings>
  <add name="AUCASA"
       connectionString="Data Source=YOUR_SERVER\SQLEXPRESS;Initial Catalog=AUCASADB_26937;Integrated Security=True;TrustServerCertificate=True"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/Pacifique16/Dot-Net-AUCASA-Application-system.git
```

2. Open the solution in Visual Studio

3. Restore NuGet packages:
   - System.Data.SqlClient
   - System.Configuration.ConfigurationManager

4. Build and run the application (F5)

## 📖 User Guide

### For Students

1. **Launch Application** → Click "Student Application"
2. **Fill in Details**:
   - Email (valid format required)
   - Full Name
   - Department (select from dropdown)
   - Semester (must be 4 or above)
   - Current Average (must be 15 or above)
   - Position (select from available positions)
3. **Click "APPLY"** to submit
4. **Check Status**: Enter email and click "CHECK"
5. **Update/Cancel**: Select application from grid and use respective buttons

### For Administrators

#### Position Management
1. **Launch Application** → Click "Position Management"
2. **Create**: Enter title and description, click "CREATE"
3. **Update**: Click on a position in the grid, modify details, click "UPDATE"
4. **Delete**: Click on a position, click "DELETE" (requires confirmation)

#### Approve/Reject Applications
1. **Launch Application** → Click "Approve/Reject"
2. **View Pending**: All pending applications are displayed
3. **Select Application**: Click on an application in the grid
4. **Approve/Reject**: Click respective button (requires confirmation)

#### Statistics Dashboard
1. **Launch Application** → Click "Statistics Dashboard"
2. **View Metrics**: See real-time statistics in color-coded panels
3. **Analyze Data**: Review applications by department and position
4. **Monitor System**: Track pending, approved, and rejected applications

## 🔒 Security Features

- ✅ SQL injection prevention (parameterized queries)
- ✅ Input validation on all forms
- ✅ Email format validation
- ✅ Confirmation dialogs for destructive operations
- ✅ Error handling with user-friendly messages
- ✅ Read-only fields in approval interface

## 🎨 UI/UX Features

- ✅ Color-coded buttons for different actions
- ✅ Intuitive navigation with main menu
- ✅ Data grids for easy data viewing
- ✅ Click-to-select functionality
- ✅ Dropdown menus for standardized inputs
- ✅ Confirmation dialogs for critical actions
- ✅ Success/Error message boxes with icons
- ✅ Statistics dashboard with real-time analytics
- ✅ Professional color-coded panels

## 🐛 Error Handling

All database operations are wrapped in try-catch blocks with:
- User-friendly error messages
- Detailed error information for debugging
- Graceful failure handling
- Transaction rollback on errors

## 📝 Validation Rules

| Field | Rule |
|-------|------|
| Email | Valid format (xxx@xxx.xxx) |
| Semester | Must be ≥ 4 |
| Average | Must be ≥ 15 |
| Department | Must select from predefined list |
| Position | Must select from available positions |
| Duplicate Applications | Cannot apply twice to same position |

## 👨‍💻 Developer Information

- **Student ID**: 26937
- **Developer**: Pacifique Harerimana
- **Email**: harerimanapacifique95@gmail.com
- **Institution**: AUCA (Adventist University of Central Africa)
- **Course**: .NET Programming

## 📄 License

This project is developed for educational purposes at AUCA.

## 🤝 Contributing

This is an academic project. For suggestions or issues, please contact the developer.

## 📞 Support

For technical support or questions:
- Email: harerimanapacifique95@gmail.com
- GitHub: [@Pacifique16](https://github.com/Pacifique16)

---

**Last Updated**: 2024
**Version**: 1.1.0 - Added Statistics Dashboard
