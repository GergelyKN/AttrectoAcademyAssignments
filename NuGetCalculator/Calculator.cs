using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuGetCalculator
{
    public class Calculator
    {
        double Add(double a, double b) => a + b;
        double Subtract(double a, double b) => a - b;
        double Multiply(double a, double b) => a * b;
        double Divide(double a, double b) => b == 0 ? throw new DivideByZeroException() : a / b;
        
    }
}