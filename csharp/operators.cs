using System;
using System.Collections.Generic;

namespace StackMachine
{
    delegate Number Monadic(Number x);
    delegate Number Dyadic(Number x, Number y);
    delegate void Operator(Stack<Number> stack);

    static class Operators
    {
        private static Operator op(Monadic fn)
        {
            return (Stack<Number> stack) =>
            {
                var x = stack.Pop();
                var y = fn(x);
                stack.Push(y);
            };
        }

        private static Operator op(Dyadic fn)
        {
            return (Stack<Number> stack) =>
            {
                var x = stack.Pop();
                var y = stack.Pop();
                var z = fn(x, y);
                stack.Push(z);
            };
        }

        public static Operator Push(double number) => Push(new Number(number));
        public static Operator Push(Number number) => (stack) => stack.Push(number);
        public static Operator Add => op((x, y) => x.Add(y));
        public static Operator Subtract => op((x, y) => x.Subtract(y));
        public static Operator Multiply => op((x, y) => x.Multiply(y));
        public static Operator Divide => op((x, y) => x.Divide(y));
    }
}
