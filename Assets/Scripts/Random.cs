using System;

public static class IntUtil
{
    private static Random random;

    private static void Init()
    {
        if (random == null) random = new Random();
    }

    public static int Random(int min, int max)
    {
        Init();
        return random.Next(min, max);
    }
}
public static class DoubleUtil
{
    private static Random random;

    private static void Init()
    {
        if (random == null) random = new Random();
    }

    public static double Random(float min, float max)
    {
        Init();
        return random.NextDouble() * (max - min) + min;
    }
}