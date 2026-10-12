//Rational Number cs code
/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: RationalNumber
 * see:https://en.wikipedia.org/wiki/Rational_number
 *--------------------------------------------------------------
 */

namespace RationalNumber;

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

public class RationalNumber
{
    //TODO Implement class here
    public int    Numerator   { get; private set; }
    public int    Denominator { get; private set; }
    public double Value       => (double)Numerator / Denominator;
    public RationalNumber(int n, int d)
    {
        Numerator   = n;
        Denominator = d;
    }

    public RationalNumber() : this(0,1) { }
    

    public RationalNumber Normalize()
    {
        int            n                  = Numerator;
        int            d                  = Denominator;
        RationalNumber r                  = new RationalNumber(n,  d);
        RationalNumber convertToRightSign = new RationalNumber(-1, -1);

        if (d == 0) return r;                       // invalid, nothing to reduce

        if (d < 0)                                  // sign always in the numerator
        {
            r = r.Mult(convertToRightSign);
            n = r.Numerator;
            d = r.Denominator;
        }

        int length = 0;
        if (Math.Abs(n) < d)
        {
            length = d;
        }
        else
        {
            length = Math.Abs(n);
        }

        if (!(n == d))
        {
            for (int i = length; i >= 2; i--)
            {
                if (d % i == 0 && n % i == 0)
                {
                    r = new RationalNumber(n / i, d / i).Normalize();
                    return r;
                }
            }
        }
        else
        {
            r = new RationalNumber(1, 1);
        }
        return r;
    }
    public RationalNumber Add(RationalNumber number)
    {
        int MulOne = 0;
        int MulTwo = 0;
        for (int i = 1; i <= Denominator * number.Denominator; i++)
        {
            for(int j = 1; j <= Denominator * number.Denominator; j++)
            {
                if (Denominator * i == number.Denominator * j)
                {
                    MulOne = i;
                    MulTwo = j;
                    return new RationalNumber(Numerator * MulOne + number.Numerator * MulTwo, Denominator * MulOne);
                }
            }
        }

        return new RationalNumber();
    }
    public  RationalNumber Div(RationalNumber number)
    {
        return new RationalNumber(Numerator * number.Denominator, Denominator * number.Numerator);
    }
    public RationalNumber Mult(RationalNumber number)
    {
        return new RationalNumber(Numerator * number.Numerator, Denominator * number.Denominator);
    }
    public RationalNumber Sub(RationalNumber number)
    {
        int MulOne = 0;
        int MulTwo = 0;
        for (int i = 1; i <= Denominator * number.Denominator; i++)
        {
            for(int j = 1; j <= Denominator * number.Denominator; j++)
            {
                if (Denominator * i == number.Denominator * j)
                {
                    MulOne = i;
                    MulTwo = j;
                    return new RationalNumber(Numerator * MulOne - number.Numerator * MulTwo, Denominator * MulOne);
                }
            }
        }

        return new RationalNumber();
    }

    public RationalNumber Inverse()
    {
        return new RationalNumber(-Numerator, Denominator);
    }

    public override string ToString()
    {
        string result = "";
        if (Denominator == 0)
        {
            result = "invalid";
        }
        else if (Numerator % Denominator == 0 && Denominator != 0)
        {
            result = Convert.ToString(Numerator / Denominator);
        }
        else
        {
            result = $"{Numerator}/{Denominator}";
        }

        return result;
    }

    public RationalNumber Reciprocal()
    {
        if(Numerator == 0) return new RationalNumber(0, 0);
        Console.WriteLine($"{Denominator}  {Numerator}");
        return new RationalNumber(Denominator, Numerator);
    }
}