
interface StackOperator
{
    static StackOperator create(FnNone fn)
    {
        return new StackOperatorNone(fn);
    }

    static StackOperator create(FnSingle fn)
    {
        return new StackOperatorSingle(fn);
    }

    static StackOperator create(FnPair fn)
    {
        return new StackOperatorPair(fn);
    }

    Stack operate(Stack stack);
}

class StackOperatorSwap implements StackOperator
{
    public Stack operate(Stack stack)
    {
        double x = stack.pull();
        double y = stack.pull();
        stack.push(x);
        stack.push(y);
        return stack;
    }
}

class StackOperatorPush implements StackOperator
{
    private double n;

    public StackOperatorPush(double n)
    {
        this.n = n;
    }

    public Stack operate(Stack stack)
    {
        stack.push(n);
        return stack;
    }
}

class StackOperatorPop implements StackOperator
{
    public Stack operate(Stack stack)
    {
        stack.pull();
        return stack;
    }
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
