using System;

namespace MetodyObliczeniowe
{
    public class Integral {
        int n;
        double a, b;
        public Integral(int n, double a, double b)
        {
            this.n = n;
            this.a = a;
            this.b = b;
        }

        private double fun1(double x, int i, int j) {
            return Math.Pow(x, i) * Math.Pow(x, j);
        }

        private double fun2(double x, int i) {
            return Math.Pow(x, i) * Math.Sqrt(x);
        }
        
        private double x(double i) {
            return a + i * ((b - a) / n);
        }

        public double calculateTheIntegralA(int lvl1, int lvl2) {
            double wynik = 0.0;
            double t;

            for (int i = 0; i < n; i++) {
                t = (x(i + 1) + x(i)) / 2;
                wynik += 4 * fun1(t, lvl1, lvl2);
            }

            for (int i = 1; i < n; i++) {
                wynik += 2 * fun1(x(i), lvl1, lvl2);
            }

            wynik += fun1(x(0), lvl1, lvl2) + fun1(x(n), lvl1, lvl2);
            double h = (x(n) - x(n - 1)) / 2;
            wynik *= h / 3;
            return wynik;
        }

        public double calculateTheIntegralB(int lvl) {
            double wynik = 0.0;
            double t;

            for (int i = 0; i < n; i++) {
                t = (x(i + 1) + x(i)) / 2;
                wynik += 4 * fun2(t, lvl);
            }

            for (int i = 1; i < n; i++) {
                wynik += 2 * fun2(x(i), lvl);
            }

            wynik += fun2(x(0), lvl) + fun2(x(n), lvl);
            double h = (x(n) - x(n - 1)) / 2;
            wynik *= h / 3;
            return wynik;
        }
    }
}