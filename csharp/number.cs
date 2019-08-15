using System;

namespace StackMachine
{
    struct Number
    {
        double Value { get; }

        public Number(double number) => Value = number;
        public Number(Number number) => Value = number.Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public Number Add(Number y) => new Number(Value + y.Value);
        public Number Subtract(Number y) => new Number(Value - y.Value);
        public Number Multiply(Number y) => new Number(Value * y.Value);
        public Number Divide(Number y) => new Number(Value / y.Value);
        public Number Power(Number y) => new Number(Math.Pow(Value, y.Value));
        public Number Root(Number y) => new Number(Math.Pow(Value, 1/y.Value));

        public Number Squared => new Number(Value * Value);
        public Number Cubed => new Number(Value * Value * Value);
        public Number SquareRoot => new Number(Math.Sqrt(Value));

        public Number Sine => new Number(Math.Sin(Value));
        public Number Cosine => new Number(Math.Cos(Value));
        public Number Tangent => new Number(Math.Tan(Value));

        public Number ArcSine => new Number(Math.Asin(Value));
        public Number ArcCosine => new Number(Math.Acos(Value));
        public Number ArcTangent => new Number(Math.Atan(Value));

        public Number Ln => new Number(Math.Log(Value));
        public Number Log => new Number(Math.Log10(Value));
        public Number LogN(Number y) => new Number(Math.Log(Value, y.Value));
        public Number Exp => new Number(Math.Exp(Value));
        public Number Exp10 => new Number(Math.Pow(Value, 10));
    }
}
