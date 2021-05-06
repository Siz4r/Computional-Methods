using System;

namespace MetodyObliczeniowe
{
   
    class Program
    {
        static int a = 1;
        static int b = 3;
        static int n = 2;
        static double[,] matrix = new double[n + 1, n + 1];
        static double[] output = new double[n + 1];
        
        static void Main(string[] args)
        {
            double[] ai = calculateMatrix();
            double wynik = 0.0;
            double x = 1.0;
            for (int i  = 0; i <= n; i++) {
                wynik += ai[i] * Math.Pow(x, i);
            }
            Console.WriteLine(Math.Round(wynik, 5));
        }

        static double[] calculateMatrix() {
            Integral calc = new Integral(50, a, b);
            
            for (int i = 0; i <= n; i++) {
                for (int j = 0; j <= n; j++) {
                    matrix[i, j] = calc.calculateTheIntegralA(i, j);
                    //Console.WriteLine($"I|J: {i}|{j} = {matrix[i, j]}");
                }
                output[i] = calc.calculateTheIntegralB(i);
                //Console.WriteLine($"I: {i} = {output[i]}");
            }
            GaussMatrix gauss = new GaussMatrix(output, matrix);
            return gauss.GetValues();
        }

        static double funkcjaGlowna(int x) {
            return Math.Sqrt(x);
        }

        static double funkcjaA(int i, int j, int x) {
            return fi(i, x) * fi(j, x) * funkcjaP();
        }

        static double funkcjaB(int i, int x) {
            return fi(i, x) * funkcjaGlowna(x) * funkcjaP();
        }

        static double funkcjaP() {
            return 1.0;
        }

        static double fi(int i, int x) {
            if (i == 0) return 1.0;
            else {
                double wynik = 1.0;
                for (int j = 0; j < i; j++) wynik *= x;
                return wynik;
            }
        }
    }
}
