﻿using System;
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

        public void Assert(double real, double imag)
        {
            Real.Should().BeApproximately(real, Modules.EPS);
            Imag.Should().BeApproximately(imag, Modules.EPS);
        }
    }

    public class DumpMachineParser
    {
        readonly List<Qubit> qubits = new List<Qubit>();

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
                //double rad = double.Parse(afterColon.Substring(75, 7));

                qubits.Add(new Qubit() { 
                    Real = real,
                    Imag = imag,
                    Prob = prob
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

        public double GetProb(int bit, bool tf)
        {
            double ret = 0;
            for (int msk = 0; msk < qubits.Count; msk++)
            {
                if (((msk & (1 << bit)) != 0) == tf)
                {
                    ret += qubits[msk].Prob;
                }
            }
            return ret;
        }
    }
}
