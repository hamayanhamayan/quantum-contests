using System.Collections.Generic;
using System.IO;

namespace QSharpContests.Tests
{
    public class DumpUnitaryParser
    {
        List<List<double>> coefficients;

        public DumpUnitaryParser(string filepathPostfix, int bit)
        {
            coefficients = new List<List<double>>();
            for (int i = 0; i < (1<<bit); i++)
            {
                coefficients.Add(new List<double>());
                var allLines = File.ReadAllLines($"{i}_{filepathPostfix}");
                for (int j = 1; j < allLines.Length; j++)
                {
                    int afCol = 0;
                    while (allLines[j][afCol] != ':') afCol++;
                    afCol++;
                    string afterColon = allLines[j].Substring(afCol);

                    string realSign = afterColon.Substring(1, 1);
                    string realVal = afterColon.Substring(2, 8);
                    double real = realSign == "-" ? -double.Parse(realVal) : double.Parse(realVal);

                    string imagSign = afterColon.Substring(11, 1);
                    string imagVal = afterColon.Substring(14, 8);
                    double imag = imagSign == "-" ? -double.Parse(imagVal) : double.Parse(imagVal);

                    double prob = double.Parse(afterColon.Substring(53, 8));

                    coefficients[i].Add(prob);
                }
            }
        }

        public double GetCoefficient(int i, int j)
        {
            return coefficients[i][j];
        }
    }
}
