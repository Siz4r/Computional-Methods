using System;

namespace Interpolacja
{
    public class Newton : InterpolationMethod
    {
        public double Calculate() {
            double result = Variables.valuesInPoints[0];
            double temp = 1.0;

            for (int i = 1; i < Variables.points.Count; i++) {
                for (int j = 0; j < i; j++) {
                    temp *= (Variables.pointToCalculate - Variables.points[j]);
                }

                result += DifferentialQuotient(i, 0) * temp;
                temp = 1.0;
            }
            return result;
        }

        private double DifferentialQuotient(int range, int position) {
            if (range == 1) return (Variables.valuesInPoints[position + 1] - Variables.valuesInPoints[position]) 
                                    / (Variables.points[position + 1] - Variables.points[position]);
            return (DifferentialQuotient(range - 1, position + 1) - DifferentialQuotient(range - 1, position)) /
                    (Variables.points[position + range] - Variables.points[position]);
        }

        
    }
}