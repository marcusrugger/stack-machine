#ifndef OPERATORS_H
#define OPERATORS_H

#include <functional>
#include "stack.h"


typedef std::function<Stack *(Stack *)> Operator;
typedef std::function<double(double)> fn_single;
typedef std::function<double(double,double)> fn_pair;

class OperatorSingle
{
private:

    fn_single fn;

public:

    OperatorSingle(fn_single f) : fn(f) {};

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = fn(x);
        stack->push(y);
        return stack;
    }

};

class OperatorPair
{
private:

    fn_pair fn;

public:

    OperatorPair(fn_pair f) : fn(f) {};

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        double z = fn(x,y);
        stack->push(z);
        return stack;
    }

};

class OperatorNumber
{
private:

    double value;

public:

    OperatorNumber(double n) : value(n) {};

    Stack *operator()(Stack *stack)
    {
        stack->push(value);
        return stack;
    }

};

class OperatorSwap
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x);
        stack->push(y);
        return stack;
    }

};


auto FnAddition = [](double x, double y) -> double
{ return x+y; };

auto FnSubtraction = [](double x, double y) -> double
{ return x-y; };

auto FnMultiplication = [](double x, double y) -> double
{ return x*y; };

auto FnDivision = [](double x, double y) -> double
{ return x/y; };


#if 0
class OperatorSwap
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x);
        stack->push(y);
        return stack;
    }

};


class OperatorAdddition
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x+y);
        return stack;
    }

};


class OperatorSubtraction
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x-y);
        return stack;
    }

};


class OperatorMultiplication
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x*y);
        return stack;
    }

};


class OperatorDivision
{
public:

    Stack *operator()(Stack *stack)
    {
        double x = stack->pull();
        double y = stack->pull();
        stack->push(x/y);
        return stack;
    }

};
#endif

#endif // OPERATORS_H
