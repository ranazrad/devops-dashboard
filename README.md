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
Open your web browser and navigate to the local address displayed
in the terminal output (usually `http://localhost:5000` or
`http://localhost:5100`). You should see the standard Slate-Blue
Enterprise Cluster Metrics Dashboard tracking active nodes.

---
## ⚡ Step 2: Live Code-Change Challenges
To simulate real-world developer tasks passing through a DevOps
pipeline, open the core configuration file located at:
`src/DevopsDashboard.App/Pages/Models.cs`

You can independently modify any of the following parameters to
alter the production application behavior:
### Challenge A: Dynamic Visual Overhaul (Theme Toggle)
Locate the `EnableCyberpunkTheme` property:
```csharp
public static bool EnableCyberpunkTheme = false;
```
**Action:** Change the value to `true`.
**Result:** The dashboard will shift from standard corporate colors
into a high-visibility ⚡ CYBERPUNK CLUSTER OPS ⚡ dark theme with
a purple-pink neon glow.
### Challenge B: Cluster Personalization (String Manipulation)
Locate the `CustomClusterName` property:
```csharp
public static string CustomClusterName =
"Production-Cluster-Alpha";
```
**Action:** Change the string value to your name or your team's
name (e.g., "Team-Delta-K8s").
**Result:** Your personalized name will appear prominently at the
top header of the dashboard, verifying that your specific container
deployment is live.
### Challenge C: Chaos Engineering (Simulating Outages)
Locate the `SimulateNodeOutage` property:
```csharp
public static bool SimulateNodeOutage = false;
```

---
## 🧪 Step 3: Verifying and Pushing Changes
**Test Locally:** After making your desired modifications, always

re-run the test suite to make sure the core logic remains
compliant:
```bash
dotnet test
```

**Commit and Push:** Commit your code modifications to Git.
**Pipeline Action:** Your Jenkins Shared Library pipeline will
automatically detect the commit, compile the updated .NET codebase,
validate the test suite, build a brand new Docker container image,
and seamlessly
