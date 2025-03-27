# Unity Zip Project Utility

A simple Unity Editor extension to zip your Unity project with essential folders (`Assets/`, `ProjectSettings/`, `Packages/`). This tool is useful for sharing or backing up Unity projects without including unnecessary files like `Library/`, `Temp/`, or `Logs/`.

---

## Features

- Quickly zip your Unity project with a single click.
- Includes only the essential folders:
  - `Assets/`
  - `ProjectSettings/`
  - `Packages/`
- Excludes unnecessary folders:
  - `Library/`
  - `Temp/`
  - `Logs/`
  - `obj/`

---
## 📦 **Installation**
### 1. 🌐 Using Git URL (Recommended)
You can install the package directly from the GitHub repository using Unity’s Package Manager.

- Open your Unity project.
- Go to `Window > Package Manager`.
- Click the **+** button in the top-left corner.
- Select **Add package from git URL...**
- Enter the following URL:
`https://github.com/farazmajid56/UnityZipProjectUtility.git`

### 2. 📦 Using Unity Package Import
- Download the `.unitypackage` file from the [Releases](https://github.com/farazmajid56/UnityZipProjectUtility/releases).
- Open Unity and import the package:
  - `Assets > Import Package > Custom Package...`

### 3. 🚀 Manual Import
- Clone or download this repository.
- Open your Unity project.
- Drag the `ZipProjectUtility` folder into the `Assets` directory of your project.
---

## Usage

1. Open your Unity project.
2. Navigate to `Tools > Zip Project` in the Unity menu bar.
3. The utility will:
   - Zip the essential project folders.
   - Save the `.zip` file in the project root directory.
   - Automatically open the folder containing the `.zip` file.

---
