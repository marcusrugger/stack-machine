
public class StackOperatorPair implements StackOperator
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
        double z = fn.fn(x, y);
        stack.push(z);
        return stack;
    }
}