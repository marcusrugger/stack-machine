using System;
using System.Collections.Generic;

namespace StackMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new Machine();

            Console.WriteLine("Hello World!");

            TestList.ForEach(test =>
            {
                RunTest(machine, test);
                ValidateTest(machine);
            });
        }

        static void RunTest(Machine machine, List<Operator> test)
        {
            test.ForEach(op => op(machine));
        }

        static void ValidateTest(Machine machine)
        {
            bool AreEqual(Number a, Number b, Number p) => a.Minus(b).AbsoluteValue.LessThanOrEqualTo(p);

            var precision = machine.Stack.Pop();
            var expected = machine.Stack.Pop();
            var actual = machine.Stack.Pop();
            var passed = AreEqual(expected, actual, precision);

            if (passed)
                Console.WriteLine($"Test PASSED: result = {actual}");
            else
                Console.WriteLine($"Test FAILED: expected = {expected}, actual = {actual}");
        }

        static List<List<Operator>> TestList = new List<List<Operator>>
        {
            TestDistanceToProximaCentauri,
            TestSquareRoot,
            TestSquaresAndSquareRoot,
            TestDivide,
            TestRemainder,
            TestFractionalPart,
            TestMachineMemory,
            TestFactorial
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

            Operators.Push(25101730417442.5),
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
            Operators.Push(0.0)
        };

        static List<Operator> TestDivide => new List<Operator>
        {
            Operators.Push(1.0),
            Operators.Push(2.0),
            Operators.Divide,

            Operators.Push(0.5),
            Operators.Push(0.0)
        };

        static List<Operator> TestRemainder => new List<Operator>
        {
            Operators.Push(3.5),
            Operators.Push(2.1),
            Operators.Remainder,

            Operators.Push(1.4),
            Operators.Push(0.0)
        };

        static List<Operator> TestFractionalPart => new List<Operator>
        {
            Operators.Push(-2.1),
            Operators.FractionalPart,

            Operators.Push(-0.1),
            Operators.Push(0.000000000001)
        };

        static List<Operator> TestMachineMemory => new List<Operator>
        {
            Operators.Push(3),
            Operators.Push(5),
            Operators.Add,
            Operators.PopToMemory(0),

            Operators.Push(7),
            Operators.Push(11),
            Operators.Add,

            Operators.PushFromMemory(0),
            Operators.Multiply,

            Operators.Push(144),
            Operators.Push(0)
        };

        static List<Operator> TestFactorial => new List<Operator>
        {
            Operators.Push(69.0),
            Operators.Factorial,

            Operators.Push(3628800.0),
            Operators.Push(0)
        };
    }
}
