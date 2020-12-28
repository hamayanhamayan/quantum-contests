using System;
using System.Collections.Generic;
using System.IO;

using FluentAssertions;

namespace QSharpContests.Tests
{
    public class Qubit
    {
        public double Real;
        public double Imag;
        public double Prob;
        public double Rad;

        public void Assert(double real, double imag)
        {
            const double EPS = 1e-5;
            Real.Should().BeApproximately(real, EPS);
            Imag.Should().BeApproximately(imag, EPS);
        }
    }

    public class DumpMachineParser
    {
        List<Qubit> qubits = new List<Qubit>();

        public DumpMachineParser(string filepath)
        {
            var allLines = File.ReadAllLines(filepath);
            for (int i = 1; i < allLines.Length; i++)
            {
                int afCol = 0;
                while (allLines[i][afCol] != ':') afCol++;
                afCol++;
                string afterColon = allLines[i].Substring(afCol);

                string realSign = afterColon.Substring(1, 1);
                string realVal = afterColon.Substring(2, 8);
                double real = realSign == "-" ? -double.Parse(realVal) : double.Parse(realVal);

                string imagSign = afterColon.Substring(11, 1);
                string imagVal = afterColon.Substring(14, 8);
                double imag = imagSign == "-" ? -double.Parse(imagVal) : double.Parse(imagVal);

                double prob = double.Parse(afterColon.Substring(53, 8));
                double rad = double.Parse(afterColon.Substring(75, 7));

                qubits.Add(new Qubit() { 
                    Real = real,
                    Imag = imag,
                    Prob = prob,
                    Rad = rad
                });
            }
        }

        public int Count()
        {
            return qubits.Count;
        }

        public Qubit GetQubit(int idx)
        {
            return qubits[idx];
        }
    }
}
