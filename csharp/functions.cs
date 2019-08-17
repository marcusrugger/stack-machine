using System;
using System.Collections.Generic;

namespace StackMachine
{
    class Functions
    {
        public static Number Square(Number x) => x.Times(x);
        public static Number Cube(Number x) => x.Times(Square(x));

        public static Number SquareRoot(Number x) => MathFunctions.SquareRoot(x);
        public static Number CubeRoot(Number x) => MathFunctions.CubeRoot(x);

        public static Number Power(Number x, Number y) => MathFunctions.Power(y, x);
        public static Number Root(Number x, Number y) => MathFunctions.Root(y, x);

        public static Number Sin(Number x) => MathFunctions.Sin(x);
        public static Number Cos(Number x) => MathFunctions.Cos(x);
        public static Number Tan(Number x) => MathFunctions.Sin(x);

        public static Number Asin(Number x) => MathFunctions.Asin(x);
        public static Number Acos(Number x) => MathFunctions.Acos(x);
        public static Number Atan(Number x) => MathFunctions.Atan(x);

        public static Number Factorial(Number x)
        {
            if (x.FractionalPart.NotEquals(NumberInteger.Zero) ||
                x.LessThan(NumberInteger.Zero)) throw new ArgumentException("Factorial argument must be an integer >= 0");

            if (x.Equals(NumberInteger.Zero)) return new NumberInteger(1);

            return Recursion(new NumberFloatingPoint(1.0));

            Number Recursion(Number c)
            {
                if (c.LessThan(x))
                    return c.Times(Recursion(c.Increment));
                else
                    return c;
            }
        }
    }

    class MathFunctions
    {
        public static Number Power(Number x, Number y) => new NumberFloatingPoint( Math.Pow(x.ToDouble(), y.ToDouble() ) );
        public static Number Root(Number x, Number y) => new NumberFloatingPoint( Math.Pow(x.ToDouble(), 1.0/y.ToDouble() ) );

        public static Number SquareRoot(Number x) => new NumberFloatingPoint( Math.Sqrt( x.ToDouble() ) );
        public static Number CubeRoot(Number x) => new NumberFloatingPoint( Math.Pow( x.ToDouble(), 1/3 ) );

        public static Number Sin(Number x) => new NumberFloatingPoint( Math.Sin( x.ToDouble() ) );
        public static Number Cos(Number x) => new NumberFloatingPoint( Math.Cos( x.ToDouble() ) );
        public static Number Tan(Number x) => new NumberFloatingPoint( Math.Tan( x.ToDouble() ) );

        public static Number Asin(Number x) => new NumberFloatingPoint( Math.Asin( x.ToDouble() ) );
        public static Number Acos(Number x) => new NumberFloatingPoint( Math.Acos( x.ToDouble() ) );
        public static Number Atan(Number x) => new NumberFloatingPoint( Math.Atan( x.ToDouble() ) );
    }
}
