# DVLD - Driver & Vehicle License Department System

A Windows Forms enterprise application for managing driver licenses, license renewals, international licenses, detained releases, driver records, test scheduling, and user authentication.

## Overview

This repository is a three-tier Windows Forms solution built around a clear Presentation, Business, and DataAccess architecture. The system is designed to support licensing workflows, driver and person records, test appointment management, and administrative user control.

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

## Setup

1. Open `DVLD.sln` in Visual Studio.
2. Set `DVLD Presentation Layer` as the startup project.
3. Update the database connection string in `DVLD DataAccess Layer\clsSettingsData.cs` if required.
4. Ensure the SQL Server database `DVLD` exists and required stored procedures are available.
5. Build the solution and run the application.
6. Login with an existing user account.

## Notes

- This project depends on SQL Server stored procedures for all core CRUD operations.
- `DB Diagram.pdf` and `Requirements.pdf` are included as design reference documents.
- The application is intended as a learning and prototype implementation of an enterprise licensing workflow.
