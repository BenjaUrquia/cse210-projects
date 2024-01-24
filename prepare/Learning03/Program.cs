using System;

class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom != 0 ? bottom : 1;
    }

    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int top)
    {
        numerator = top;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int bottom)
    {
        denominator = bottom != 0 ? bottom : 1;
    }

    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}

class Program
{
    static void Main()
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(6);
        Fraction fraction3 = new Fraction(6, 7);

        Console.WriteLine($"Initial Fraction 1: {fraction1.GetFractionString()}");
        fraction1.SetNumerator(3);
        fraction1.SetDenominator(4);
        Console.WriteLine($"Updated Fraction 1: {fraction1.GetFractionString()}");

        Console.WriteLine($"Decimal Value of Fraction 2: {fraction2.GetDecimalValue()}");
        Console.WriteLine($"Decimal Value of Fraction 3: {fraction3.GetDecimalValue()}");
    }
}
