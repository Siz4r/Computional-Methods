using System.Linq;
using System.Collections.Generic;
using System;

namespace Interpolacja
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, InterpolationMethod> methods = 
                new Dictionary<string, InterpolationMethod>() {
                    { "Newton", new Newton() },
                    { "Lagrange", new Lagrange() },
                    { "Spline functions", new SplineFunctions() },
                    { "Progressive Differences", new ProgressiveDifferences() }
                }; 
            
            foreach(var pair in methods) {
                Console.WriteLine($"{pair.Key}: Result is => {pair.Value.Calculate()}");
            }
            
        }
    }
}
