# StudentManagementApp

### ASP.NET Core MVC application demonstrating EF Core Code-First, relational data modeling, seeded data, eager loading, and SQL Server persistence

StudentManagementApp is a focused ASP.NET Core MVC application for displaying students together with their associated grades.

The project demonstrates a straightforward Entity Framework Core Code-First workflow using SQL Server, an explicit one-to-many relationship between students and grades, database seeding, migrations, eager loading, and read-only Razor presentation.

---

## Application Flow

```text
Browser
   ↓
StudentsController
   ↓
Entity Framework Core
   ↓
SQL Server
   ↓
Student + Grades
   ↓
Razor View
```

The application opens directly to the student overview and displays each student together with the grades associated with that record.

---

## Data Model

The application uses two related entities:

```text
Student
   │
   │ 1
   │
   └──────── *
            Grade
```

### Student

A student record contains:

- `StudentID`
- `StudentName`
- `DateOfBirth`
- `Height`
- `Weight`
- collection of associated `Grades`

### Grade

A grade record contains:

- `GradeId`
- `GradeName`
- `Section`
- `StudentId`
- navigation property to `Student`

`StudentId` acts as the foreign key connecting each grade to its student.

---

## EF Core Code-First

The database schema is defined from the application models and managed through Entity Framework Core migrations.

The project includes an initial migration that creates the relational schema for:

```text
Students
Grades
```

The relationship between the entities is represented through the foreign key on `Grade`.

This project focuses specifically on the Code-First workflow: application models define the database structure, while migrations track and apply schema changes.

---

## Seeded Data

The database is initialized with a small deterministic dataset defined through EF Core model configuration.

The seed contains:

```text
4 students
12 grades
```

Each student has associated grade records covering several subjects.

This allows the relational model and eager-loading behavior to be demonstrated immediately after applying the database migration.

---

## Data Loading

The student overview uses an asynchronous EF Core query:

```csharp
var studentsWithGrades = await _context.Students
    .AsNoTracking()
    .Include(s => s.Grades)
    .ToListAsync();
```

`Include` eagerly loads the related grade records together with each student.

Because the page is read-only, `AsNoTracking()` avoids unnecessary change tracking for the retrieved entities.

The resulting object graph is passed directly to the Razor view for presentation.

---

## User Interface

The application uses ASP.NET Core MVC and Razor views with Bootstrap styling.

Each student is displayed in a separate card containing:

- name
- date of birth
- height
- weight
- table of associated subjects and grades

The application intentionally keeps the UI focused on presenting the relational data rather than implementing broader student-management workflows.

---

## Configuration

The SQL Server connection string is configured through:

```text
appsettings.json
```

using the standard configuration key:

```text
ConnectionStrings:DefaultConnection
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=StudentManagementDB;Integrated Security=true;TrustServercertificate=true;"
  }
}
```

The included configuration uses Windows authentication with a local SQL Server Express instance and contains no database password.

For another SQL Server environment, update the connection string accordingly.

---

## Database Setup

The project includes an EF Core migration and seeded data.

Using Visual Studio Package Manager Console:

```powershell
Update-Database
```

Alternatively, with the .NET CLI and EF Core tools installed:

```bash
dotnet ef database update
```

This creates or updates `StudentManagementDB` according to the included migration.

---

## Running Locally

### Prerequisites

- .NET 10 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 or newer, or another compatible .NET development environment

### Run

Clone the repository:

```bash
git clone https://github.com/AlanRacic/StudentManagementApp.git
cd StudentManagementApp
```

Restore dependencies:

```bash
dotnet restore
```

Apply the database migration:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run --project StudentManagementApp
```

The application opens directly to the student and grade overview.

---

## Technology Stack

- C#
- .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- EF Core Code-First
- EF Core Migrations
- LINQ
- Razor
- Bootstrap

---

## Design Scope

StudentManagementApp is intentionally a focused relational-data application rather than a full student administration system.

Its purpose is to demonstrate:

- EF Core Code-First database development
- one-to-many relational modeling
- migrations and deterministic seed data
- asynchronous relational queries
- eager loading with `Include`
- read-only queries with `AsNoTracking`
- Razor-based presentation of related data

Features such as authentication, authorization, CRUD administration, service layers, APIs, background processing, or cloud deployment are outside the scope of this project.

---

## License

This project is licensed under the MIT License.
