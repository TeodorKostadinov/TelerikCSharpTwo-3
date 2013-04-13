using System;

class AddsPolynomials
{
    static void PolyAdd(int[,] polynom1, int[,] polynom2, int[,] polynom3)
    {

        int len1 = polynom1.GetLength(0);
        int len2 = polynom2.GetLength(0);
        int len3 = polynom2.GetLength(0);
        int degree1 = PolyMaxDegree(polynom1);
        int degree2 = PolyMaxDegree(polynom2);
        int degree3 = degree1;
        if (degree2 > degree1) degree3 = degree2;
        int p1 = 0, p2 = 0, p3 = 0, idx = 0;

        for (p3 = degree3; p3 >= 0; p3--)
        {
            for (p1 = 0; p1 < len1; p1++)
            {
                if (polynom1[p1, 1] == p3)
                {
                    polynom3[idx, 0] = polynom1[p1, 0];
                    polynom3[idx, 1] = p3;
                    break;
                }
            }

            for (p2 = 0; p2 < len2; p2++)
            {
                if (polynom2[p2, 1] == p3)
                {
                    polynom3[idx, 0] = polynom3[idx, 0] + polynom2[p2, 0];
                    polynom3[idx, 1] = p3;
                    break;
                }
            }
            if (p1 <= len1 || p2 <= len2) idx++;
        }
    }

    static int PolyMaxDegree(int[,] polinom)
    {
        int degree = 0;
        for (int p = 0; p < polinom.GetLength(0); p++)
        {
            if (polinom[p, 1] > degree)
                degree = polinom[p, 1];
        }
        return degree;
    }
    static void PolyInit(int[,] polinom, int index, int coef, int degree)
    {
        polinom[index, 0] = coef;
        polinom[index, 1] = degree;
    }

    static void PolyDislpay(int[,] polynom)
    {
        int len = polynom.GetLength(0);
        Console.Write("(");
        for (int p = 0; p < len; p++)
        {
            if (polynom[p, 0] == 0) continue;

            if (polynom[p, 0] == -1)
                Console.Write("-");
            else
            {
                if (polynom[p, 0] > 0) Console.Write("+");
                if (polynom[p, 0] != 1) Console.Write("{0}", polynom[p, 0]);
            }

            if (polynom[p, 1] > 1)
                Console.Write("x^{0}", polynom[p, 1]);
            else
                if (polynom[p, 1] == 1) Console.Write("x");
        }
        Console.Write(")");
    }

    static void Main()
    {
        /*Write a method that adds two polynomials.
          Represent them as arrays of their coefficients as in the example below: x2 + 5 = 1x2 + 0x + 5  |5|0|1|*/

        int[,] polynom1 = new int[4, 2];
        int[,] polynom2 = new int[5, 2];
        int[,] polynom3 = new int[9, 2];

        /* adds the term of polynomial to the arrays */
        PolyInit(polynom1, 0, -2, 4); /*term 1 */
        PolyInit(polynom1, 1, 3, 2); /* term 2 */
        PolyInit(polynom1, 2, 5, 1); /* term 3 */
        PolyInit(polynom1, 3, 8, 0); /* term 4 */

        PolyInit(polynom2, 0, -2, 4); /*term 1*/
        PolyInit(polynom2, 1, -3, 3); /*term 2 */
        PolyInit(polynom2, 2, 4, 2); /*term 3 */
        PolyInit(polynom2, 3, -1, 1); /*term 4 */
        PolyInit(polynom2, 4, 3, 0); /*term 5 */

        /* displays the polynomial equation */
        PolyDislpay(polynom1);
        Console.Write("+");
        PolyDislpay(polynom2);

        /* adds two polynomials  */
        PolyAdd(polynom1, polynom2, polynom3);

        /* displays polynomial result */
        Console.Write("=");
        PolyDislpay(polynom3);
        Console.WriteLine();
    }
}