using System;
using System.Collections.Generic;

namespace StackMachine
{
    delegate Number Monadic(Number x);
    delegate Number Dyadic(Number x, Number y);
    delegate void Operator(Stack<Number> stack);

    static class Operators
    {
        private static Operator op(Monadic fn) => (Stack<Number> stack) => stack.Push( fn( stack.Pop() ) );
        private static Operator op(Dyadic fn) => (Stack<Number> stack) => stack.Push( fn( stack.Pop(), stack.Pop() ) );

        public static Operator Push(double number) => Push(new Number(number));
        public static Operator Push(Number number) => (stack) => stack.Push(number);

        public static Operator Add => op((x, y) => x.Add(y));
        public static Operator Subtract => op((x, y) => x.Subtract(y));
        public static Operator Multiply => op((x, y) => x.Multiply(y));
        public static Operator Divide => op((x, y) => x.Divide(y));
        public static Operator Power => op((x, y) => x.Power(y));
        public static Operator Root => op((x, y) => x.Root(y));

        public static Operator Square => op((x) => x.Squared);
        public static Operator Cube => op((x) => x.Cubed);
        public static Operator SquareRoot => op((x) => x.SquareRoot);

        public static Operator Sine => op((x) => x.Sine);
        public static Operator Cosine => op((x) => x.Cosine);
        public static Operator Tangent => op((x) => x.Tangent);

        public static Operator ArcSine => op((x) => x.ArcSine);
        public static Operator ArcCosine => op((x) => x.ArcCosine);
        public static Operator ArcTangent => op((x) => x.ArcTangent);

        public static Operator Ln => op((x) => x.Ln);
        public static Operator Log => op((x) => x.Log);
        public static Operator LogN => op((x, y) => x.LogN(y));
        public static Operator Exp => op((x) => x.Exp);
        public static Operator Exp10 => op((x) => x.Exp10);
    }
}
