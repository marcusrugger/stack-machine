

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

        for (int i = 0; i < this.size; i++)
            this.stack[i] = other.stack[i];
    }

    public void push(double x)
    {
        if (index < size)
            stack[index++] = x;
    }

    public double pull()
    {
        double rv = 0;
        if (index > 0)
            rv = stack[--index];
        return rv;
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