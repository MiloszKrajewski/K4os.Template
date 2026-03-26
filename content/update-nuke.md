# Nuke Build System Update Steps

## 1. Update `global.json`

Change the .NET SDK version:

```json
"version": "8.0.101"  →  "10.0.104"
```

## 2. Update `.nuke/build/_build.csproj`

- Change target framework:
  ```
  <TargetFramework>net8.0</TargetFramework>  →  <TargetFramework>net10.0</TargetFramework>
  ```
- Update Nuke.Common package:
  ```
  Nuke.Common 9.0.4  →  10.1.0
  ```
- Update GitVersion.Tool download:
  ```
  GitVersion.Tool 6.5.1  →  6.7.0
  ```

## 3. Update `.github/workflows/continuous.yml`

- Bump `actions/checkout`:
  ```
  actions/checkout@v4  →  actions/checkout@v6
  ```
- Bump `actions/upload-artifact`:
  ```
  actions/upload-artifact@v4  →  actions/upload-artifact@v5
  ```
