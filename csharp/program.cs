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
    }
}
