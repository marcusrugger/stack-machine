#include <cmath>
#include <iostream>
#include <memory>
#include <vector>
#include "stack.cpp"
#include "operators.h"


typedef std::vector<Operator> OperatorList;


void run(Stack &stack, OperatorList &oplist)
{
    for (auto op : oplist)
        op(&stack);
}


void test1(void)
{
    std::unique_ptr<Stack> stack_one(new StackLIFO);
    const int max = 10;

    for (int i = 0; i < max; i++)
        stack_one->push(double(i));

    std::unique_ptr<Stack> stack_two(stack_one->clone());

    while (stack_two->isMore())
        std::cout << stack_two->pull() << std::endl;
}


void test2(void)
{
    StackLIFO stack;
    OperatorList oplist;

    oplist.push_back(OperatorNumber(186282.3976));
    oplist.push_back(OperatorNumber(3600));
    oplist.push_back(OperatorNumber(24));
    oplist.push_back(OperatorNumber(365.25));
    oplist.push_back(OperatorNumber(4.27));
    oplist.push_back(OperatorPair(FnMultiplication));
    oplist.push_back(OperatorPair(FnMultiplication));
    oplist.push_back(OperatorPair(FnMultiplication));
    oplist.push_back(OperatorPair(FnMultiplication));

    run(stack, oplist);

    std::cout << stack.pull() << std::endl;
}


void test3(void)
{
    StackLIFO stack;
    OperatorList oplist;

    oplist.push_back(OperatorNumber(123));
    oplist.push_back(OperatorSingle( [](double a) -> double { return std::sin(a); } ));

    run(stack, oplist);

    std::cout << stack.pull() << std::endl;
}


int main(int argc, char **argv)
{
    test1();
    test2();
    test3();
    return 0;
}
