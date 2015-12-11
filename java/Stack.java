
public interface Stack
{
    void push(double x);
    double pull();

    boolean hasMore();

    Stack clone();
}
