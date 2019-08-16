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
                var precision = stack.Pop();
                var shouldbe = stack.Pop();
                var actual = stack.Pop();
                var passed = AreEqual(shouldbe, actual, precision);
                if (passed)
                    Console.WriteLine($"Test PASSED: result {actual}");
                else
                    Console.WriteLine($"Test FAILED: should be {shouldbe}, actual {actual}");
            }
        }

        static bool AreEqual(Number a, Number b, Number p) => a.Minus(b).AbsoluteValue.LessThanOrEqualTo(p);

        static List<List<Operator>> TestList = new List<List<Operator>>
        {
            TestDistanceToProximaCentauri,
            TestSquareRoot,
            TestSquaresAndSquareRoot,
            TestDivide,
            TestRemainder,
            TestFractionalPart
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

            Operators.Push(25101730417442.5),//(186282.3976*3600*24*365.25*4.27)
            Operators.Push(0.1)
        };

        static List<Operator> TestSquareRoot => new List<Operator>
        {
            Operators.Push(2),
            Operators.Push(8),
            Operators.Multiply,
            Operators.SquareRoot,

            Operators.Push(4),
            Operators.Push(0)
        };

        static List<Operator> TestSquaresAndSquareRoot => new List<Operator>
        {
            Operators.Push(3.0),
            Operators.Square,

            Operators.Push(4.0),
            Operators.Square,

            Operators.Add,
            Operators.SquareRoot,

            Operators.Push(5.0),
            Operators.Push(0)
        };

        static List<Operator> TestDivide => new List<Operator>
        {
            Operators.Push(1.0),
            Operators.Push(2.0),
            Operators.Divide,

            Operators.Push(0.5),
            Operators.Push(0.000000001)
        };

        static List<Operator> TestRemainder => new List<Operator>
        {
            Operators.Push(3.5),
            Operators.Push(2.1),
            Operators.Remainder,

            Operators.Push(1.4),
            Operators.Push(0.000000001)
        };

        static List<Operator> TestFractionalPart => new List<Operator>
        {
            Operators.Push(-2.1),
            Operators.FractionalPart,

            Operators.Push(-0.1),
            Operators.Push(0.000000001)
        };
    }
}
