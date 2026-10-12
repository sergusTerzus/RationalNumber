//Program dot cs code
/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: RationalNumber
 *--------------------------------------------------------------
 */

namespace RationalNumber;

using System;

class Program
{
    public static void Main()
    {
        RationalNumber bestPi = CalcBestPiApproximation(1000);

        Console.WriteLine($"Best Pi approximation: {bestPi.ToString()}={bestPi.Value} (Diff:) {DiffToPi(bestPi)}");
        RationalNumber inv = new RationalNumber(10, 2).Inverse();
        Console.WriteLine(inv.Numerator);
        Console.WriteLine(inv.Denominator);
        Console.WriteLine(inv);
    }

    static RationalNumber CalcBestPiApproximation(int limit)
    {
        RationalNumber best     = new RationalNumber(3, 1);
        double         bestDiff = DiffToPi(best);

        for (int d = 1; d < limit; d++)
        {
            int n = (int)Math.Round(Math.PI * d);
            if (n >= limit) break;

            RationalNumber candidate = new RationalNumber(n, d);
            double         diff      = DiffToPi(candidate);
            if (diff < bestDiff)
            {
                best     = candidate;
                bestDiff = diff;
            }
        }
        return best;
    }
    //TODO: Write CalcBestPiApproximation
    
    
    //TODO: Write DiffToPi (calculated with double)
    static double DiffToPi(RationalNumber r) => Math.Abs(r.Value - Math.PI);
}