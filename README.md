# DVLD - Driver & Vehicle License Department System

Comprehensive enterprise application for managing driving licenses, vehicle registrations, and related documentation.

## Architecture

```
DVLD/
├── DVLD Presentation Layer/     - WinForms UI, login, forms and user controls
├── DVLD Buisness Layer/         - Business logic and domain objects
└── DVLD DataAccess Layer/       - ADO.NET data access, SQL Server stored procedures
```

## Main Modules

- **Authentication & Users**
  - Login form and role-aware access control
  - User account management and credentials

- **Driver & Person Management**
  - Driver profile management
  - Person details and contact information
  - Driver license records linked to person entities

- **License Management**
  - Local driving license issuance and renewal
  - International license issuance
  - License replacement for damaged or lost credentials
  - Detained license release workflows

- **Application Workflows**
  - License application processing
  - Application type and status management
  - Local and international license application forms

- **Tests & Appointments**
  - Driving test scheduling and appointment tracking
  - Written and practical test management
  - Question bank support for exam preparation

- **Logging & Settings**
  - Error logging through `clsLoggingData`
  - Global settings and configuration management

## Implementation Details

- `DVLD Presentation Layer` is a WinForms application targeting .NET Framework 4.7.2.
- The entry point is `Configs\Program.cs`, which launches `frmLogin`.
- `DVLD Buisness Layer` contains domain classes for licenses, drivers, applications, users, tests, and related business rules.
- `DVLD DataAccess Layer` uses `System.Data.SqlClient` and stored procedures to read and write data to the `DVLD` SQL Server database.
- The presentation layer references a custom control library: `WindowsFormsControlLibrary1.dll`.

## Technologies

- .NET Framework 4.7.2
- Windows Forms
- ADO.NET / `System.Data.SqlClient`
- SQL Server
- 3-tier architecture
- C#

## 📊 Layers

### Presentation Layer

- Web UI components
- Controllers and action methods
- User input handling
- Data display

### Business Layer

- Business logic implementation
- Business rules enforcement
- Data validation
- Transaction management

### Data Access Layer

- Database operations
- Query execution
- Repository pattern
- Data entity mapping

## 🚀 Getting Started

1. Update connection string in configuration
2. Run database setup scripts
3. Create initial data (users, roles, test types)
4. Start application
5. Login with admin credentials

## 🔐 Security

- User authentication
- Role-based authorization
- SQL injection prevention
- Password hashing
- Audit trails

## 📈 Scalability

- Modular architecture
- Database optimization
- Proper indexing
- Connection pooling

---

This is a large, production-like system. Study each layer to understand enterprise architecture patterns.
