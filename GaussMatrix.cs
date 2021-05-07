using System;
using System.Collections.Generic;

namespace Interpolacja
{
    public class GaussMatrix {
        private double[] output;
        private double[] lastColumn;
        private List<List<double>> matrix;

        public GaussMatrix(double[] lastColumn, List<List<double>> matrix)
        {
            this.output = new double[lastColumn.Length];
            this.lastColumn = lastColumn;
            this.matrix = matrix;
        }

        public double[] GetValues() {
            

            for (int i = 0; i < matrix[0].Count; i++) {
                ComplementOfMatrix(i);
            }

            for (int i = matrix[0].Count - 1; i >= 0; i--) {
                output[i] = lastColumn[i] / matrix[i][i];
                int temp = matrix[0].Count - i;

                for (int j = matrix[0].Count - 1; j >= 0; j--) {
                    if (matrix[i][j] != 0.0 && i != j) 
                        output[i] -= matrix[i][j] / matrix[i][i] * output[j];
                }
            }

            return output;
        }

        private double[,] ComplementOfMatrix(int start) {
            int temp = matrix[0].Count - start;
            double[,] outputMatrix = new double[temp, temp];
            double[] column = new double[temp];

            for (int i = 0; i < temp; i++) {
                for (int j = 0; j < temp; j++) {
                    outputMatrix[i,j] = matrix[i + start][j + start];
                    column[i] = lastColumn[i + start];
                }
            }
            ZeroingTheColumns(outputMatrix, outputMatrix[0, 0], column);

            for (int i = 0; i < temp; i++) {
                for (int j = 0; j < temp; j++) {
                    matrix[i + start][j + start] = outputMatrix[i, j];
                    lastColumn[i + start] = column[i];
                }
            }
            
            return outputMatrix;
        }

        private void ZeroingTheColumns(double[,] outputMatrix, double x, double[] column) {
            double temp1;
            double temp2;
            for (int i = 1; i < outputMatrix.GetLength(1); i++) {
                temp1 = outputMatrix[i, 0];
                temp2 = column[0];
                for (int j = 0; j < outputMatrix.GetLength(1); j++) {
                    if (x != 0.0)
                        outputMatrix[i, j] -= outputMatrix[0, j] * temp1 / x;
                }

                if (x != 0.0)
                    column[i] -= temp2 * temp1 / x;
            }
        }
    }
}