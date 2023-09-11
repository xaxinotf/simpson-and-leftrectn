
using System;

class Program
{
    static double Function(double x)
    {
        return x * Math.Exp(-x * x / 2) + Math.Sin(x);
    }

    static double SimpsonRule(double a, double b, double h)
    {
        int n = (int)((b - a) / (2 * h));
        double result = 0;

        for (int i = 0; i <= n; i++)
        {
            double x = a + 2 * i * h;
            result += Function(x) + 4 * Function(x + h) + Function(x + 2 * h);
        }

        result *= h / 3;
        return result;
    }

    static void Main()
    {
        double epsilon = 1e-4;
        double h = 0.01;
        double a = 1;
        double b = double.PositiveInfinity;

        double integral = 0;
        double integralPrev = double.MaxValue;
        int iteration = 0;

        while (Math.Abs(integral - integralPrev) > epsilon)
        {
            iteration++;
            integralPrev = integral;
            integral = SimpsonRule(a, a + iteration * h, h);
        }

        Console.WriteLine($"приблизний результатик iнтегралу, варiк 45: {integral:F6}");
    }
}












/*

using System;
using System.Linq;

class Program
{
    // Function to calculate the value of the integrand at a given point x
    static double Integrand(double x)
    {
        if (x == 0.0)
        {
            // Handle the singularity at x = 0
            return 0.0;
        }
        return (1.0 / (x * x * x)) * Math.Exp(-(1.0 / (x * x)) / 2) + Math.Sin(1.0 / x);
    }

    // Simpson's rule for numerical integration
    static double SimpsonsRule(double a, double b, int n)
    {
        double h = (b - a) / n;
        double result = Integrand(a) + Integrand(b);

        for (int i = 1; i < n; i += 2)
        {
            result += 4.0 * Integrand(a + i * h);
        }

        for (int i = 2; i < n - 1; i += 2)
        {
            result += 2.0 * Integrand(a + i * h);
        }

        return (h / 3.0) * result;
    }

    static void Main()
    {
        double epsilon = 1e-4;
        double h = 0.01;
        double a = 0.0;
        double b = 1.0;

        int n = 1; // Initial number of intervals

        double integralPrev = 0.0;
        double integralCurrent = SimpsonsRule(a, b, n);
        double error = Math.Abs(integralCurrent - integralPrev);

        while (error >= epsilon)
        {
            n *= 2;
            integralPrev = integralCurrent;
            integralCurrent = SimpsonsRule(a, b, n);
            error = Math.Abs(integralCurrent - integralPrev);
        }

        Console.WriteLine("Approximate integral: " + integralCurrent);
    }
}

*/
















/*
using System;


class Program
{
    static double Function(double t)
    {
        return 1 / t * Math.Exp(-(-Math.Log(t))) / (1 + (-Math.Log(t)));
    }

    static double LeftRectangleMethod(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = 0.0;

        for (int i = 0; i < n; i++)
        {
            double x = a + i * h;
            sum += Function(x);
        }

        return h * sum;
    }

    static void Main()
    {
        double a = 1e-6; // ловер ліміт  (уникати ділення на 0)
        double b = 1.0;  // апер ліміт of інтеграції
        double epsilon = 1e-1; 

        int n = 1; // початкова кількість підінтервалів
        double result = 0.0;
        double previousResult = double.MaxValue;

        while (Math.Abs(result - previousResult) >= epsilon)
        {
            previousResult = result;
            n *= 2;
            result = LeftRectangleMethod(a, b, n);
        }

        Console.WriteLine("приблизний результатик iнтегралу, варiк 31: " + result);
    }
}


*/
















/*
using System;

class Program
{
    static double Function(double t)
    {
        if (t == 0)
        {
            // Handle the singularity at t = 0
            return 0;
        }

        return (1 / (t * t)) * (1 / t) * Math.Exp(-0.5 * (1 / (t * t))) + Math.Sin(1 / t);
    }

    static double SimpsonRule(double a, double b, int n)
    {
        double h = (b - a) / n;
        double sum = Function(a) + Function(b);

        for (int i = 1; i < n; i++)
        {
            double x = a + i * h;
            sum += i % 2 == 0 ? 2 * Function(x) : 4 * Function(x);
        }

        return (h / 3) * sum;
    }

    static void Main()
    {
        double a = 0.001; // Adjust the lower limit to avoid t = 0 singularity
        double b = 1;
        double epsilon = 1e-4;
        double integral = 0;
        double prevIntegral = double.MaxValue;
        int n = 2; // Initial number of subintervals

        while (Math.Abs(integral - prevIntegral) > epsilon)
        {
            prevIntegral = integral;
            integral = SimpsonRule(a, b, n);
            n *= 2;
        }

        Console.WriteLine($"Approximate Integral: {integral}");
    }
}

*/
