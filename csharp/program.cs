using System;
using System.Collections.Generic;

namespace StackMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var stack = new Stack<Number>();

            foreach (var test in TestList)
            {
                foreach (var op in test) op(stack);
                var shouldbe = stack.Pop();
                var actual = stack.Pop();
                var passed = actual.Equals(shouldbe);
                if (passed)
                    Console.WriteLine($"Test PASSED: result {actual}");
                else
                    Console.WriteLine($"Test FAILED: should be {shouldbe}, actual {actual}");
            }
        }

        static List<List<Operator>> TestList = new List<List<Operator>>
        {
            TestDistanceToProximaCentauri,
            TestSquareRoot,
            TestSquaresAndSquareRoot,
            TestDivide,
            TestRemainder
        };

        static List<Operator> TestDistanceToProximaCentauri => new List<Operator>
        {
            Operators.Push(186282.3976),
            Operators.Push(3600),
            Operators.Multiply,

            Operators.Push(24),
            Operators.Multiply,

            Operators.Push(365.25),
            Operators.Multiply,

            Operators.Push(4.27),
            Operators.Multiply,

            Operators.Push(186282.3976*3600*24*365.25*4.27)
        };

        static List<Operator> TestSquareRoot => new List<Operator>
        {
            Operators.Push(2),
            Operators.Push(8),
            Operators.Multiply,
            Operators.SquareRoot,

            Operators.Push(4)
        };

        static List<Operator> TestSquaresAndSquareRoot => new List<Operator>
        {
            Operators.Push(3),
            Operators.Square,

            Operators.Push(4),
            Operators.Square,

            Operators.Add,
            Operators.SquareRoot,

            Operators.Push(5)
        };

        static List<Operator> TestDivide => new List<Operator>
        {
            Operators.Push(1.0),
            Operators.Push(2.0),
            Operators.Divide,

            Operators.Push(0.5)
        };

        static List<Operator> TestRemainder => new List<Operator>
        {
            Operators.Push(3.5),
            Operators.Push(2.1),
            Operators.Remainder,

            Operators.Push(1.4)
        };
    }
}
