
class FnNumber implements FnNone
{
    private double n;

    public FnNumber(double n)
    {
        this.n = n;
    }

    public double fn()
    {
        return n;
    }
}

class FnBasicMath
{
    public static double add(double x, double y)
    {
        return x+y;
    }

    public static double subtract(double x, double y)
    {
        return x-y;
    }

    public static double multiply(double x, double y)
    {
        return x*y;
    }

    public static double divide(double x, double y)
    {
        return x/y;
    }

    public static double square(double x)
    {
        return x*x;
    }
}
