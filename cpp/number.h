#ifndef NUMBER_H
#define NUMBER_H


#include <stdexcept>


class Type
{
public:

    virtual Type Add(const Type &y) = 0;
    virtual Type Subtract(const Type &y) = 0;
    virtual Type Multiply(const Type &y) = 0;
    virtual Type Divide(const Type &y) = 0;

};


class BaseType : public Type
{
public:

    Type Add(const Type &y)
    { throw new runtime_error("Add not implemented"); }

    Type Subtract(const Type &y)
    { throw new runtime_error("Subtract not implemented"); }

    Type Multiply(const Type &y)
    { throw new runtime_error("Multiply not implemented"); }

    Type Divide(const Type &y)
    { throw new runtime_error("Divide not implemented"); }    

};


class Number
{
private:

    double value;


public:

    Number(double v) : value(v) {}


    Number Add(const Number &y)
    { return new Number(value + y.value); }

    Number Subtract(const Number &y)
    { return new Number(value - y.value); }

    Number Multiply(const Number &y)
    { return new Number(value * y.value); }

    Number Divide(const Number &y)
    { return new Number(value / y.value); }

};


#endif // NUMBER_H
