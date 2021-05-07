using System;

namespace Interpolacja 
{
    public class Lagrange : InterpolationMethod
    {
        public double Calculate() {
            double result = 0.0;
            double temp = 1.0;
            for (int i = 0; i < Variables.points.Count; i++) {
                for (int j = 0; j < Variables.points.Count; j++) {
                    if (i != j) {
                        temp *= (Variables.pointToCalculate - Variables.points[j]) / 
                                (Variables.points[i] - Variables.points[j]);
                    }
                }
                result += Variables.valuesInPoints[i] * temp;
                temp = 1.0;
            }
            return result;
        }
    }
}