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

        public static Operator Push(Int64 number) => Push(new NumberInteger(number));
        public static Operator Push(double number) => Push(new NumberFloatingPoint(number));
        public static Operator Push(Number number) => (stack) => stack.Push(number);

        public static Operator FractionalPart => op((x) => x.FractionalPart);

        public static Operator Add => op((x, y) => y.Plus(x));
        public static Operator Subtract => op((x, y) => y.Minus(x));
        public static Operator Multiply => op((x, y) => y.Times(x));
        public static Operator Divide => op((x, y) => y.DividedBy(x));
        public static Operator Remainder => op((x, y) => y.Remainder(x));

        public static Operator Power => op(Functions.Power);
        public static Operator Root => op(Functions.Root);

        public static Operator AbsoluteValue => op((x) => x.AbsoluteValue);
        public static Operator Floor => op((x) => x.Floor);
        public static Operator Ceiling => op((x) => x.Ceiling);

        public static Operator Square => op(Functions.Square);
        public static Operator Cube => op(Functions.Cube);
        public static Operator SquareRoot => op(Functions.SquareRoot);
        public static Operator CubeRoot => op(Functions.CubeRoot);

        public static Operator Sine => op(Functions.Sin);
        public static Operator Cosine => op(Functions.Cos);
        public static Operator Tangent => op(Functions.Tan);

        public static Operator ArcSine => op(Functions.Asin);
        public static Operator ArcCosine => op(Functions.Acos);
        public static Operator ArcTangent => op(Functions.Atan);
    }
}
