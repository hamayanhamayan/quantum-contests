using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;

using System.Threading.Tasks;
using System;

using FluentAssertions;

namespace QSharpContests.Tests
{
    [TestClass]
    public class QSharpCodingContestWinter2019WarmupTests
    {
        [TestMethod]
        async public Task ProblemG1_1()
        {
            var bits = new QArray<bool>(new bool[] { true, true, true, true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG1.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemG1_2()
        {
            var bits = new QArray<bool>(new bool[] { true, true, false, true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG1.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(false);
        }

        [TestMethod]
        async public Task ProblemG1_3()
        {
            var bits = new QArray<bool>(new bool[] { false, false, false, false });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG1.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(false);
        }
        [TestMethod]
        async public Task ProblemG2_1()
        {
            var bits = new QArray<bool>(new bool[] { true, true, true, true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG2.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemG2_2()
        {
            var bits = new QArray<bool>(new bool[] { true, true, false, true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG2.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemG2_3()
        {
            var bits = new QArray<bool>(new bool[] { false, false, false, false });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG2.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(false);
        }

        [TestMethod]
        async public Task ProblemG3_1()
        {
            var bits = new QArray<bool>(new bool[] { false, false, false, false });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG3.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemG3_2()
        {
            var bits = new QArray<bool>(new bool[] { true, false, true, false });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG3.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(false);
        }

        [TestMethod]
        async public Task ProblemG3_3()
        {
            var bits = new QArray<bool>(new bool[] { true, false, true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG3.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemG3_4()
        {
            var bits = new QArray<bool>(new bool[] { true });
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool res = await QSharpCodingContestWinter2019Warmup.ProblemG3.Driver.Run(sim, bits, dumpPath);
            res.Should().Be(true);
        }

        [TestMethod]
        async public Task ProblemU1_2()
        {
            int N = 2;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestWinter2019Warmup.ProblemU1.Driver.Run(sim, N, dumpPath);
            DumpUnitaryParser parser = new DumpUnitaryParser(dumpPath, N);
            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    if (i + j == (1 << N) - 1)
                    {
                        parser.GetCoefficient(i, j).Should().BeGreaterThan(Modules.EPS);
                    }
                    else
                    {
                        parser.GetCoefficient(i, j).Should().BeLessThan(Modules.EPS);
                    }
                }
            }
        }

        [TestMethod]
        async public Task ProblemU2_2()
        {
            int N = 2;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestWinter2019Warmup.ProblemU2.Driver.Run(sim, N, dumpPath);
            DumpUnitaryParser parser = new DumpUnitaryParser(dumpPath, N);
            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    int a = i / 2;
                    int b = j / 2;
                    int c = a % 2 + b % 2;

                    if (c % 2 == 0)
                    {
                        parser.GetCoefficient(i, j).Should().BeGreaterThan(Modules.EPS);
                    }
                    else
                    {
                        parser.GetCoefficient(i, j).Should().BeLessThan(Modules.EPS);
                    }
                }
            }
        }

        [TestMethod]
        async public Task ProblemU3_2()
        {
            int N = 2;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestWinter2019Warmup.ProblemU3.Driver.Run(sim, N, dumpPath);
            DumpUnitaryParser parser = new DumpUnitaryParser(dumpPath, N);
            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    bool top = i < (1 << (N - 1));
                    bool left = j < (1 << (N - 1));

                    if (top && left)
                    {
                        if (i + j == (1 << (N - 1)) - 1)
                        {
                            parser.GetCoefficient(i, j).Should().BeGreaterThan(Modules.EPS);
                        }
                        else
                        {
                            parser.GetCoefficient(i, j).Should().BeLessThan(Modules.EPS);
                        }
                    }
                    else if (!top && !left)
                    {
                        parser.GetCoefficient(i, j).Should().BeGreaterThan(Modules.EPS);
                    }
                    else
                    {
                        parser.GetCoefficient(i, j).Should().BeLessThan(Modules.EPS);
                    }
                }
            }
        }
    }
}
