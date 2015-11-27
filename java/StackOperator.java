
interface StackOperator
{
    Stack operate(Stack stack);
}

class StackOperatorNone implements StackOperator
{
    private FnNone fn;

    public StackOperatorNone(FnNone fn)
    {
        this.fn = fn;
    }

    public Stack operate(Stack stack)
    {
        double a = fn.fn();
        stack.push(a);
        return stack;
    }
}

class StackOperatorSingle implements StackOperator
{
    private FnSingle fn;

    public StackOperatorSingle(FnSingle fn)
    {
        this.fn = fn;
    }

    public Stack operate(Stack stack)
    {
        double x = stack.pull();
        double a = fn.fn(x);
        stack.push(a);
        return stack;
    }
}

class StackOperatorPair implements StackOperator
{
    private FnPair fn;

    public StackOperatorPair(FnPair fn)
    {
        this.fn = fn;
    }

    public Stack operate(Stack stack)
    {
        double x = stack.pull();
        double y = stack.pull();
        double a = fn.fn(x, y);
        stack.push(a);
        return stack;
    }
}
