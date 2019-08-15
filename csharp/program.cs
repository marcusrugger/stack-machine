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
            var oplist = new List<Operator>();

            oplist.Add(Operators.Push(new Number(186282.3976)));
            oplist.Add(Operators.Push(new Number(3600)));
            oplist.Add(Operators.Push(new Number(24)));
            oplist.Add(Operators.Push(new Number(365.25)));
            oplist.Add(Operators.Push(new Number(4.27)));
            oplist.Add(Operators.Multiply());
            oplist.Add(Operators.Multiply());
            oplist.Add(Operators.Multiply());
            oplist.Add(Operators.Multiply());

            oplist.ForEach(f => f(stack));

            var result = stack.Pop();

            Console.WriteLine($"Result: {result}");
        }
    }
}
