# NuGetCalculator

## Description

The **NuGetCalculator** is a simple calculator package that provides basic arithmetic operations for .NET 8.0.

## Installation

Install the package using the NuGet package manager:

```sh
dotnet add package GergelyKN.NuGetCalculator.Calculator
```

or using the NuGet Package Manager:

```powershell
Install-Package GergelyKN.NuGetCalculator.Calculator
```

## Usage

```csharp
using NuGetCalculator;

var calculator = new Calculator();
Console.WriteLine($"Addition: {calculator.Add(5, 3)}");        // Output: Addition: 8
Console.WriteLine($"Subtraction: {calculator.Subtract(5, 3)}"); // Output: Subtraction: 2
Console.WriteLine($"Multiplication: {calculator.Multiply(5, 3)}"); // Output: Multiplication: 15
Console.WriteLine($"Division: {calculator.Divide(6, 3)}");     // Output: Division: 2
```

## Available Operations

| Method     | Description                                                                      | Example               |
| ---------- | -------------------------------------------------------------------------------- | --------------------- |
| `Add`      | Adds two numbers                                                                 | `Add(5, 3) → 8`       |
| `Subtract` | Subtracts the second number from the first                                       | `Subtract(5, 3) → 2`  |
| `Multiply` | Multiplies two numbers                                                           | `Multiply(5, 3) → 15` |
| `Divide`   | Divides the first number by the second (throws an exception if dividing by zero) | `Divide(6, 3) → 2`    |

## License

This project is available under the MIT License

---

Created by [GergelyKN](https://github.com/GergelyKN)
