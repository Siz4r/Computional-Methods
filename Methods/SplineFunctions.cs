using System;
using System.Collections.Generic;

namespace Interpolacja
{
    public class SplineFunctions : InterpolationMethod
    {
        GaussMatrix gauss;
        public double Calculate() {
            for (int i = 0; i < Variables.n; i++) {
                getAMatrix(Variables.points[i], false, i);
            }
            getAMatrix(Variables.derivativePoint1, true, 0);
            getAMatrix(Variables.derivativePoint2, true);

            gauss = new GaussMatrix(Variables.lastColumn.ToArray(), Variables.unknown);

            return output(gauss.GetValues());
        }
        

        private void getAMatrix(double x, bool derirative, int temp = 4) {
            var row = new List<double>();
            for (int i = 0; i < Variables.lastColumn.Count; i++) {
                row.Add(0.0);
            }
            if (!derirative) {
                row[0] = 1.0;
                row[1] = x;
                row[2] = x * x;
                row[3] = x * x * x;
                if (temp > 0) {
                    for (int i = 1; i < temp; i++) {
                        row[i + 3] += Math.Pow((x - Variables.points[i]), 3.0);
                    }
                }
            } else {
                row[1] = 1.0;
                row[2] = 2 * x;
                row[3] = 3 * x * x;
                for (int i = 1; i < temp; i++) {
                    row[i + 3] += 3 * Math.Pow((x - Variables.points[i]), 2.0);
                }
            }
            foreach(double k in row) {
            }
            Variables.unknown.Add(row);
        }

        private double output(double[] gaussResult) {
            var x = Variables.pointToCalculate;
            var temp = 0;
            if (x < Variables.points[0]) temp = 0;
            else if (x > Variables.points[Variables.points.Count - 1]) 
                temp = Variables.points.Count - 1;
            else {
                for (int i = 1; i < Variables.points.Count; i++) {
                    if (x >= Variables.points[i - 1] 
                    && x <= Variables.points[i])
                        temp = i;
                }
            }

            var result = gaussResult[0] +
                         gaussResult[1] * x +
                         gaussResult[2] * x * x +
                         gaussResult[3] * x * x * x;
            for (int i = 1; i < temp; i++) {
                result += gaussResult[i + 3] * Math.Pow((x - Variables.points[i]), 3.0);
            }

            return result;
        }
    }
}