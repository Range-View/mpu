# MPU - [Range View] Main Processing Unit

## Project Overview

The MPU (Main Processing Unit) is designed to manage core processing tasks within a modular architecture. This project organizes various components such as third-party libraries, main application logic, I/O operations, user interface, and data analysis into a single multi-proj-solution - That would be integrated into the Physical MPU mounted on the Field Monitor.

- **Build** - `dotnet build MPU.sln`
- **Run** - `dotnet run --project MPU/MPU.csproj`

# Directory Structure


- **MPU/** - Root directory.
  - **libs/** - Third-party and common libraries.
  - **src/** - Source code.
    -  **IO/** - Module for Input/Output operations with sensors.
    -  **UI/** - User Interface module.
    -  **Analysis/** - Data analysis module.
  - **test/** - Performance tests + Development tests.
    -  **IO/** 
    -  **UI/** 
    -  **.../**
  - **include/** - All public entities (classes/interfaces).
  - **tools/** - Public Generic Helpers.
  - **resources/** - Static resources (json/txt).
  - `CMakeLists.txt` - Startup item.
  - `MPU.csproj` - Entry point.
  - `.gitignore`
 
