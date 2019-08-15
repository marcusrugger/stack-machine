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
    }
}