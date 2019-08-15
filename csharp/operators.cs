using System;
using System.Collections.Generic;

namespace StackMachine
{
    delegate Number Monadic(Number x);
    delegate Number Dyadic(Number x, Number y);
    delegate void Operator(Stack<Number> stack);

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

        public Operator Create(Dyadic fn)
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
}