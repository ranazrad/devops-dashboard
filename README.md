# DevOps Lab: .NET 8 CI/CD & Kubernetes Deployment Challenge
Welcome to the DevOps Cluster Dashboard lab. This repository
contains a modern Blazor WebAssembly application designed to
simulate an enterprise-grade development and deployment lifecycle.
Through this lab, you will run the app locally, execute an
automated test suite, and perform multiple application
modifications to see how code and configuration changes dynamically
shift a live production environment.

---
## 📂 Repository Structure
* **`src/DevopsDashboard.App/`** - Frontend Blazor WebAssembly
cluster metrics dashboard (styled with Tailwind CSS).
* **`tests/DevopsDashboard.Tests/`** - XUnit test suite containing
12 unit tests verifying cluster validation logic and layout
settings.

---
## 🚀 Step 1: Local Setup & Verification
Before automating your build via a CI/CD pipeline, verify that the
application compiles and passes health checks locally.
### 1. Prerequisites
Ensure you have the **.NET 8 SDK** installed on your machine:

```bash
dotnet --version
```

### 2. Restore Dependencies & Build
Navigate to the repository root directory (where the
`DevopsDashboard.sln` file is located) and execute:
```bash
dotnet restore
dotnet build --configuration Release
```

### 3. Run the Test Suite
Run the 12 automated unit tests to guarantee that the codebase is
completely healthy:
```bash
dotnet test --configuration Release
```
*Note: All 12 tests must pass with a green status before any
pipeline execution.*
### 4. Launch the Web Application
Run the dashboard locally to see its default operational state:
```bash
dotnet run --project
src/DevopsDashboard.App/DevopsDashboard.App.csproj
```
