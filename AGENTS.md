# Repository Guidelines

## Project Structure & Module Organization
Open the solution via `NoMoreDistantRoost.sln` to load the mod project. Game code lives in `ExamplePlugin/`, with `NoMoreDistantRoost.cs` as the primary entry point and `Log.cs` providing a thin logging wrapper. Build artifacts land under `ExamplePlugin/bin/` and `ExamplePlugin/obj/`; clean these before publishing. Thunderstore packaging assets reside in `Thunderstore/`, where `manifest.json`, `README.md`, and the `plugins/` payload mirror the expected upload structure.

## Build, Test, and Development Commands
Run `dotnet restore NoMoreDistantRoost.sln` once after cloning to hydrate dependencies such as `BepInEx` and `R2API`. Use `dotnet build NoMoreDistantRoost.sln -c Release` to generate the plugin DLL in `ExamplePlugin/bin/Release/netstandard2.1/`. For ad-hoc checks during development, `dotnet build ExamplePlugin/NoMoreDistantRoost.csproj` without a configuration flag is sufficient. After a successful build, copy the produced `ExamplePlugin.dll` into `Thunderstore/plugins/MyFirstMod/` (or your renamed folder) to keep the package up to date.

## Coding Style & Naming Conventions
Match the existing C# style: four-space indentation, PascalCase for classes and public members, camelCase for locals, and ALL_CAPS for item token names. Update `PluginAuthor`, `PluginName`, and `PluginVersion` constants together to keep the `PluginGUID` accurate and unique. Keep log statements routed through the `Log` helper to ensure consistent output formatting. Use `LangVersion` preview features only when essential, documenting any new language requirement in the PR description.

## Testing Guidelines
The template ships without automated tests; add them under a sibling project (for example `ExamplePlugin.Tests`) and wire it into the solution. When tests exist, execute them via `dotnet test`. Until then, validate gameplay changes in-game: confirm the custom item spawns, applies buffs, and respects inventory counts; capture screenshots or short clips for complex changes.

## Commit & Pull Request Guidelines
Commit history is not bundled with this template, so adopt a Conventional Commits style (`feat:`, `fix:`, `docs:`) to broadcast intent clearly. Keep commits scoped to a logical change set and include context on affected systems. Pull requests should describe the feature or fix, list manual test steps, and link to any tracking issue. Attach updated Thunderstore assets or screenshots whenever the user-facing experience changes.
