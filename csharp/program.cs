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

            Test1(stack);
            Console.WriteLine($"Result: {stack.Pop()}");

            Test2(stack);
            Console.WriteLine($"Result: {stack.Pop()}");

            Test3(stack);
            Console.WriteLine($"Result: {stack.Pop()}");
        }

        static void Test1(Stack<Number> stack)
        {
            Operators.Push(186282.3976)(stack);
            Operators.Push(3600)(stack);
            Operators.Multiply(stack);

            Operators.Push(24)(stack);
            Operators.Multiply(stack);

            Operators.Push(365.25)(stack);
            Operators.Multiply(stack);

            Operators.Push(4.27)(stack);
            Operators.Multiply(stack);
        }

        static void Test2(Stack<Number> stack)
        {
            Operators.Push(2)(stack);
            Operators.Push(8)(stack);
            Operators.Multiply(stack);
            Operators.SquareRoot(stack);
        }

        static void Test3(Stack<Number> stack)
        {
            Operators.Push(3)(stack);
            Operators.Square(stack);

            Operators.Push(4)(stack);
            Operators.Square(stack);

            Operators.Add(stack);
            Operators.SquareRoot(stack);
        }
    }
}
