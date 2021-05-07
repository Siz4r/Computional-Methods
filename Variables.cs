using System.Collections.Generic;

namespace Interpolacja
{
    public static class Variables {

        public static readonly List<double> points = new List<double>() {
            -4.0,
            -2.0,
             0.0,
             2.0,
             4.0
        };

        public static readonly List<double> valuesInPoints = new List<double>() {
            -96.0,
             6.0,
            -4.0,
            -30.0,
            -360.0
        };

        public static readonly int n = 5;
        public static readonly List<double> lastColumn = new List<double>() {
            -96.0,
            -2.0,
            -4.0,
            -30.0,
            -360.0,
             143.0, 
             -337.0
        };

        public static readonly double pointToCalculate = 3.0;

        public static readonly double derivativePoint1 = -4.0, derivativePoint2 = 4.0;

        /* First point minus second point */
        public static readonly double h = 2.0;

        public static List<List<double>> unknown = new List<List<double>>();
    }
}