using System;

namespace Interpolacja
{
    public class ProgressiveDifferences : InterpolationMethod
    {
        public double Calculate() {
            double result = Variables.valuesInPoints[0];
            double temp = 1.0;
            for (int i = 1; i < Variables.n; i++) {
                for (int j = 0; j < i; j++) {
                    temp *= Variables.pointToCalculate - Variables.points[j];
                }
                result = result + (ProgressiveDiff(i, 0) / (strongNumber(i) * Math.Pow(Variables.h, i))) * temp;
                temp = 1.0;
                
            }
            return result;
        }

        private double ProgressiveDiff(int range, int position) {
            if (range == 1) return Variables.valuesInPoints[position + 1] - Variables.valuesInPoints[position];
            return ProgressiveDiff(range - 1, position + 1) - ProgressiveDiff(range - 1, position); 
        }

        private int strongNumber(int temp) {
            int result = 1;
            for (int i = 1; i <= temp; i++) result *= i;
            return result;
        }
    }
}