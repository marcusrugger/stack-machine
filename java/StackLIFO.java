import java.lang.RuntimeException;

public class StackLIFO implements Stack
{
    private int size;
    private int index;
    private double stack[];

    public StackLIFO()
    {
        this(128);
    }

    public StackLIFO(int size)
    {
        this.size   = size;
        this.index  = 0;
        this.stack  = new double[this.size];
    }

    public StackLIFO(StackLIFO other)
    {
        this.size   = other.size;
        this.index  = other.index;
        this.stack  = new double[this.size];

        for (int i = 0; i < this.index; i++)
            this.stack[i] = other.stack[i];
    }

    public void push(double x)
    {
        if (index < size)
            stack[index++] = x;
        else
            throw new RuntimeException("Stack overflow");
    }

    public double pull()
    {
        if (index > 0)
            return stack[--index];
        else
            throw new RuntimeException("Stack underflow");
    }

    public boolean hasMore()
    {
        return index > 0;
    }

    public Stack clone()
    {
        return new StackLIFO(this);
    }
}
