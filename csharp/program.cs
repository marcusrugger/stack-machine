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
            var testlist = new List<List<Operator>>
            {
                TestDistanceToProximaCentauri,
                TestSquareRoot,
                TestSquaresAndSquareRoot,
                TestDivide,
                TestRemainder
            };

            foreach (var test in testlist)
            {
                foreach (var op in test) op(stack);
                Console.WriteLine($"Result: {stack.Pop()}");
            }
        }

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
            Operators.Multiply
        };

        static List<Operator> TestSquareRoot => new List<Operator>
        {
            Operators.Push(2),
            Operators.Push(8),
            Operators.Multiply,
            Operators.SquareRoot
        };

        static List<Operator> TestSquaresAndSquareRoot => new List<Operator>
        {
            Operators.Push(3),
            Operators.Square,

            Operators.Push(4),
            Operators.Square,

            Operators.Add,
            Operators.SquareRoot
        };

        static List<Operator> TestDivide => new List<Operator>
        {
            Operators.Push(1.0),
            Operators.Push(2.0),
            Operators.Divide
        };

        static List<Operator> TestRemainder => new List<Operator>
        {
            Operators.Push(3.5),
            Operators.Push(2.1),
            Operators.Remainder
        };
    }
}
