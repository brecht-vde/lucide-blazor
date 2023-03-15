# lucide-blazor

Blazor adaption for the Lucide icon pack. For a list of available icons check https://lucide.dev/ or find them in the Lucide repository.

## Installation

To add nuget sources for this package, follow [these steps](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry).

```bash
dotnet add <your_project.csproj> package Lucide.Blazor 
```

## Usage

Import the following in your razor files:

```razor
@using Lucide.Blazor.Components
```

### Basic

```razor
<Icon Name="bug" />
```
### Change color

```razor
<Icon Name="bug" Stroke="blue" />
```

### Change size

```razor
<Icon Name="bug" Width="100" Height="100" />
```

### Apply css classes

```razor
<Icon Name="bug" Css="icon-style" />
```

### More examples

Check the [example project](/examples/) for a running project.

## Licenses

Check the [license](/LICENSE) file for this repository.
Check the [license](https://github.com/lucide-icons/lucide/blob/main/LICENSE) file for Lucide icons.
