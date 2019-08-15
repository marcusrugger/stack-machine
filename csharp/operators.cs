using System;
using System.Collections.Generic;

namespace StackMachine
{
    delegate Number Monadic(Number x);
    delegate Number Dyadic(Number x, Number y);
    delegate void Operator(Stack<Number> stack);

    class OperatorPush
    {
        Number number { get; }

        public static Operator Create(Number number)
            => new OperatorPush(number).f;

        private OperatorPush(Number number) => this.number = number;

        private void f(Stack<Number> stack)
        {
            stack.Push(number);
        }
    }

    class OperatorMonadic
    {
        Monadic fn { get; }

        public Operator Create(Monadic fn)
            => new OperatorMonadic(fn).f;

        private OperatorMonadic(Monadic fn) => this.fn = fn;

        private void f(Stack<Number> stack)
        {
            var x = stack.Pop();
            var y = fn(x);
            stack.Push(y);
        }
    }

    class OperatorDyadic
    {
        Dyadic fn { get; }

        public static Operator Create(Dyadic fn)
            => new OperatorDyadic(fn).f;

        private OperatorDyadic(Dyadic fn) => this.fn = fn;

        private void f(Stack<Number> stack)
        {
            var x = stack.Pop();
            var y = stack.Pop();
            var z = fn(x, y);
            stack.Push(z);
        }
    }

    static class Operators
    {
        public static Operator Push(Number number)
            => OperatorPush.Create(number);

        public static Operator Add()
            => OperatorDyadic.Create((x, y) => x.Add(y));

        public static Operator Subtract()
            => OperatorDyadic.Create((x, y) => x.Subtract(y));

        public static Operator Multiply()
            => OperatorDyadic.Create((x, y) => x.Multiply(y));

        public static Operator Divide()
            => OperatorDyadic.Create((x, y) => x.Divide(y));
    }
}