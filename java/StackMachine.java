
public class StackMachine
{
    public static void test1()
    {
        Stack stack = new StackLIFO();

        for (int x = 0; x < 10; x++)
            stack.push(x);

        Stack clone = stack.clone();

        while (stack.hasMore())
            System.out.println(stack.pull());

        for (int x = 100; x < 110; x++)
            stack.push(x);

        while (clone.hasMore())
            System.out.println(clone.pull());
    }

    public static void test2()
    {
        Stack stack = new StackLIFO();

        stack.push(12);
        stack.push(23);

        StackOperator op = new StackOperatorPair(FnBasicMath::multiply);

        op.operate(stack);

        System.out.println(stack.pull());
    }

    public static void main(String[] args)
    {
        test1();
        test2();
    }
}
