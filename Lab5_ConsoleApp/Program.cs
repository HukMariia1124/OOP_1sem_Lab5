using System;
using System.Collections.Generic;
using Lab5_WpfApp.Models;

class Program
{
    static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b);
        curr = curr.Add(curr);
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }
    static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing (a-b) = (a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");

        try
        {
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            T aMinusB = a.Subtract(b);
            Console.WriteLine("(a - b) = " + aMinusB);
            
            Console.WriteLine(" = = = ");

            T a2 = a.Multiply(a);
            Console.WriteLine("a^2 = " + a2);
            T b2 = b.Multiply(b);
            Console.WriteLine("b^2 = " + b2);
            T a2MinusB2 = a2.Subtract(b2);

            T aPlusB = a.Add(b);

            Console.WriteLine("(a^2 - b^2) = " + a2MinusB2);
            Console.WriteLine("(a + b) = " + aPlusB);

            T rightPart = a2MinusB2.Divide(aPlusB);
            Console.WriteLine("(a^2-b^2)/(a+b) = " + rightPart);

            Console.WriteLine("=== Finishing testing ===");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Caught expected DivideByZeroException during testing (likely a+b == 0).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    static void TestDivideByZero<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing DivideByZeroException with a = " + a + ", b = " + b + " ===");
        try
        {
            Console.WriteLine($"Attempting to divide {a} by {b}...");
            a.Divide(b);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("SUCCESS: DivideByZeroException caught correctly.");
        }
        Console.WriteLine("=== Finishing testing ===");
    }
    static void TestSorting<T>(List<T> fracs) where T : IMyNumber<T>
    {
        Console.WriteLine("\n=== Starting testing Sorting (IComparable<MyFrac>) ===");

        Console.WriteLine("Before sorting:");
        Console.WriteLine(string.Join(", ", fracs));

        fracs.Sort();

        Console.WriteLine("After sorting:");
        Console.WriteLine(string.Join(", ", fracs));
        Console.WriteLine("=== Finishing testing ===");
    }

    static void Main()
    {
        TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

        TestSquaresDifference(new MyFrac(1, 2), new MyFrac(1, 3));
        TestSquaresDifference(new MyComplex(1, 1), new MyComplex(2, 2));

        TestDivideByZero(new MyFrac(1, 2), new MyFrac(0, 5));

        TestSorting(new List<MyFrac>
        {
            new MyFrac(1, 2),
            new MyFrac(1, 3),
            new MyFrac(3, 4),
            new MyFrac("-1/2"),
            new MyFrac(0, 1)
        }
        );

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}