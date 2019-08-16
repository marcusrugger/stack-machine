using System;

namespace StackMachine
{
    abstract class Number
    {
        public abstract Int64 ToInteger();
        public abstract double ToDouble();

        public virtual bool Equals(Number y) => throw new NotImplementedException();
        public virtual bool NotEquals(Number y) => throw new NotImplementedException();
        public virtual bool LessThan(Number y) => throw new NotImplementedException();
        public virtual bool GreaterThan(Number y) => throw new NotImplementedException();
        public virtual bool LessThanOrEqualTo(Number y) => throw new NotImplementedException();
        public virtual bool GreaterThanOrEqualTo(Number y) => throw new NotImplementedException();

        public virtual Number Plus(Number y) => throw new NotImplementedException();
        public virtual Number Minus(Number y) => throw new NotImplementedException();
        public virtual Number Times(Number y) => throw new NotImplementedException();
        public virtual Number DividedBy(Number y) => throw new NotImplementedException();
        public virtual Number Remainder(Number y) => throw new NotImplementedException();

        public virtual Number AbsoluteValue => throw new NotImplementedException();
        public virtual Number Floor => throw new NotImplementedException();
        public virtual Number Ceiling => throw new NotImplementedException();
        public virtual Number Truncate => throw new NotImplementedException();
        public virtual Number Round => throw new NotImplementedException();
        public virtual Number FractionalPart => throw new NotImplementedException();
    }

    class NumberInteger : Number
    {
        Int64 Value { get; }

        public NumberInteger(Int64 number) => Value = number;
        public NumberInteger(Number number) => Value = number.ToInteger();

        public override Int64 ToInteger() => Value;
        public override double ToDouble() => (double)Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(Number y) => (Value == y.ToInteger());
        public override bool NotEquals(Number y) => (Value != y.ToInteger());
        public override bool LessThan(Number y) => (Value < y.ToInteger());
        public override bool GreaterThan(Number y) => (Value > y.ToInteger());
        public override bool LessThanOrEqualTo(Number y) => (Value <= y.ToInteger());
        public override bool GreaterThanOrEqualTo(Number y) => (Value >= y.ToInteger());

        public override Number Plus(Number y) => new NumberInteger(Value + y.ToInteger());
        public override Number Minus(Number y) => new NumberInteger(Value - y.ToInteger());
        public override Number Times(Number y) => new NumberInteger(Value * y.ToInteger());
        public override Number DividedBy(Number y) => new NumberInteger(Value / y.ToInteger());
        public override Number Remainder(Number y) => new NumberInteger(Value % y.ToInteger());

        public override Number AbsoluteValue => new NumberInteger(Math.Abs(Value));
        public override Number Floor => this;
        public override Number Ceiling => this;
        public override Number Truncate => this;
        public override Number Round => this;
        public override Number FractionalPart => new NumberInteger(0);
    }

    class NumberFloatingPoint : Number
    {
        double Value { get; }

        public NumberFloatingPoint(double number) => Value = number;
        public NumberFloatingPoint(Number number) => Value = number.ToDouble();

        public override Int64 ToInteger() => (Int64)Value;
        public override double ToDouble() => Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(Number y) => (Value == y.ToDouble());
        public override bool NotEquals(Number y) => (Value != y.ToDouble());
        public override bool LessThan(Number y) => (Value < y.ToDouble());
        public override bool GreaterThan(Number y) => (Value > y.ToDouble());
        public override bool LessThanOrEqualTo(Number y) => (Value <= y.ToDouble());
        public override bool GreaterThanOrEqualTo(Number y) => (Value >= y.ToDouble());

        public override Number Plus(Number y) => new NumberFloatingPoint(Value + y.ToDouble());
        public override Number Minus(Number y) => new NumberFloatingPoint(Value - y.ToDouble());
        public override Number Times(Number y) => new NumberFloatingPoint(Value * y.ToDouble());
        public override Number DividedBy(Number y) => new NumberFloatingPoint(Value / y.ToDouble());
        public override Number Remainder(Number y) => new NumberFloatingPoint(Value % y.ToDouble());

        public override Number AbsoluteValue => new NumberFloatingPoint(Math.Abs(Value));
        public override Number Floor => new NumberFloatingPoint(Math.Floor(Value));
        public override Number Ceiling => new NumberFloatingPoint(Math.Ceiling(Value));
        public override Number Truncate => new NumberFloatingPoint(Math.Truncate(Value));
        public override Number Round => new NumberFloatingPoint(Math.Round(Value));
        public override Number FractionalPart => new NumberFloatingPoint(Value - Math.Truncate(Value));
    }
}
