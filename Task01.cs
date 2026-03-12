using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SprintExercise_12_03_2026
{
    public class Task01
    {
        /* public static void Run()
        {
            float float1 = 3.80f;
            string str1 = "h";
            double double1 = 2.5;
            int num1 = 2;
            decimal dec1 = num1;
            // the one above is called `Implicit Conversion`: int can be converted to float, double, decimal without casting
            Console.WriteLine(dec1);
            decimal decimal1 = 1.1m;
            double double2 = (double)decimal1;
            // the one above is called `Explicit Conversione`: float and double use `binary floating-point math (Base-2)`, wherase decimal uses `decimal floating-point math (Base-10)` so it needs casting
            Console.WriteLine(double2);
            float float2 = 2.9f;
            int num2 = (int)float2;
            // we need an Explicit Conversiont when converting from an higher precision to a lower precision
            Console.WriteLine(num2);
            decimal decimal3 = (decimal)float2;
            Console.WriteLine(decimal3);
            double double3 = 3.678908765436578;
            float float3 = (float)double3;
            Console.WriteLine(float3);
            // we can implicitly convert a float into a double:
            float float4 = 4.15f;
            double double4 = float4;
        }
        */
        public static int MultiplyInt(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
