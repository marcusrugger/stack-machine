using System;

namespace StackMachine
{
    abstract class Number
    {
        public abstract int ToInteger();
        public abstract double ToDouble();

        public virtual Number Add(Number y) => throw new NotImplementedException();
        public virtual Number Subtract(Number y) => throw new NotImplementedException();
        public virtual Number Multiply(Number y) => throw new NotImplementedException();
        public virtual Number Divide(Number y) => throw new NotImplementedException();
        public virtual Number Power(Number y) => throw new NotImplementedException();
        public virtual Number Root(Number y) => throw new NotImplementedException();

        public virtual Number AbsoluteValue => throw new NotImplementedException();

        public virtual Number Squared => throw new NotImplementedException();
        public virtual Number Cubed => throw new NotImplementedException();
        public virtual Number SquareRoot => throw new NotImplementedException();
        public virtual Number CubeRoot => throw new NotImplementedException();

        public virtual Number Sine => throw new NotImplementedException();
        public virtual Number Cosine => throw new NotImplementedException();
        public virtual Number Tangent => throw new NotImplementedException();

        public virtual Number ArcSine => throw new NotImplementedException();
        public virtual Number ArcCosine => throw new NotImplementedException();
        public virtual Number ArcTangent => throw new NotImplementedException();

        public virtual Number Ln => throw new NotImplementedException();
        public virtual Number Log => throw new NotImplementedException();
        public virtual Number LogN(Number y) => throw new NotImplementedException();
        public virtual Number Exp => throw new NotImplementedException();
        public virtual Number Exp10 => throw new NotImplementedException();
    }

    class NumberInteger : Number
    {
        int Value { get; }

        public NumberInteger(int number) => Value = number;
        public NumberInteger(Number number) => Value = number.ToInteger();

        public override int ToInteger() => Value;
        public override double ToDouble() => (double)Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public override Number Add(Number y) => new NumberInteger(Value + y.ToInteger());
        public override Number Subtract(Number y) => new NumberInteger(Value - y.ToInteger());
        public override Number Multiply(Number y) => new NumberInteger(Value * y.ToInteger());
        public override Number Divide(Number y) => new NumberInteger(Value / y.ToInteger());
        public override Number Power(Number y) => new NumberInteger((int)Math.Pow(Value, y.ToDouble()));
        public override Number Root(Number y) => new NumberDouble(Math.Pow(Value, 1/y.ToDouble()));

        public override Number AbsoluteValue => new NumberInteger(Math.Abs(Value));

        public override Number Squared => new NumberInteger(Value * Value);
        public override Number Cubed => new NumberInteger(Value * Value * Value);
        public override Number SquareRoot => new NumberDouble(Math.Sqrt(Value));
        public override Number CubeRoot => new NumberDouble(Math.Pow(Value, 1/3));

        public override Number Sine => new NumberDouble(Math.Sin(Value));
        public override Number Cosine => new NumberDouble(Math.Cos(Value));
        public override Number Tangent => new NumberDouble(Math.Tan(Value));

        public override Number ArcSine => new NumberDouble(Math.Asin(Value));
        public override Number ArcCosine => new NumberDouble(Math.Acos(Value));
        public override Number ArcTangent => new NumberDouble(Math.Atan(Value));

        public override Number Ln => new NumberDouble(Math.Log(Value));
        public override Number Log => new NumberDouble(Math.Log10(Value));
        public override Number LogN(Number y) => new NumberDouble(Math.Log(Value, y.ToDouble()));
        public override Number Exp => new NumberDouble(Math.Exp(Value));
        public override Number Exp10 => new NumberInteger((int)Math.Pow(Value, 10));
    }

    class NumberDouble : Number
    {
        double Value { get; }

        public NumberDouble(double number) => Value = number;
        public NumberDouble(Number number) => Value = number.ToDouble();

        public override int ToInteger() => (int)Value;
        public override double ToDouble() => Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public override Number Add(Number y) => new NumberDouble(Value + y.ToDouble());
        public override Number Subtract(Number y) => new NumberDouble(Value - y.ToDouble());
        public override Number Multiply(Number y) => new NumberDouble(Value * y.ToDouble());
        public override Number Divide(Number y) => new NumberDouble(Value / y.ToDouble());
        public override Number Power(Number y) => new NumberDouble(Math.Pow(Value, y.ToDouble()));
        public override Number Root(Number y) => new NumberDouble(Math.Pow(Value, 1/y.ToDouble()));

        public override Number AbsoluteValue => new NumberDouble(Math.Abs(Value));

        public override Number Squared => new NumberDouble(Value * Value);
        public override Number Cubed => new NumberDouble(Value * Value * Value);
        public override Number SquareRoot => new NumberDouble(Math.Sqrt(Value));
        public override Number CubeRoot => new NumberDouble(Math.Pow(Value, 1/3));

        public override Number Sine => new NumberDouble(Math.Sin(Value));
        public override Number Cosine => new NumberDouble(Math.Cos(Value));
        public override Number Tangent => new NumberDouble(Math.Tan(Value));

        public override Number ArcSine => new NumberDouble(Math.Asin(Value));
        public override Number ArcCosine => new NumberDouble(Math.Acos(Value));
        public override Number ArcTangent => new NumberDouble(Math.Atan(Value));

        public override Number Ln => new NumberDouble(Math.Log(Value));
        public override Number Log => new NumberDouble(Math.Log10(Value));
        public override Number LogN(Number y) => new NumberDouble(Math.Log(Value, y.ToDouble()));
        public override Number Exp => new NumberDouble(Math.Exp(Value));
        public override Number Exp10 => new NumberDouble(Math.Pow(Value, 10));
    }
}
