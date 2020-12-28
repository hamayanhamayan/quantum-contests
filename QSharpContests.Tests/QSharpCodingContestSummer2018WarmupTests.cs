using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Quantum.Simulation.Simulators;
using System.Threading.Tasks;
using System;
using FluentAssertions;

namespace QSharpContests.Tests
{
    [TestClass]
    public class QSharpCodingContestSummer2018WarmupTests
    {
        [TestMethod]
        async public Task ProblemA_plus()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // |+>
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, 1, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b0).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b1).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemA_minus()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // |->
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, -1, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b0).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b1).Assert(-1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemB_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // |Φ+> = 00と11の重ね合わせ状態 (|00> + |11>)/sqrt(2)
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 0, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b01).Assert(0, 0);
            parser.GetQubit(0b10).Assert(0, 0);
            parser.GetQubit(0b11).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemB_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // | Φ-> = 00と11の重ね合わせ状態(| 00 > - | 11 >) / sqrt(2)
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 1, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b01).Assert(0, 0);
            parser.GetQubit(0b10).Assert(0, 0);
            parser.GetQubit(0b11).Assert(-1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemB_2()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // | ψ +> = 01と10の重ね合わせ状態(| 01 > + | 10 >) / sqrt(2)
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 2, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(0, 0);
            parser.GetQubit(0b01).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b10).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b11).Assert(0, 0);
        }

        [TestMethod]
        async public Task ProblemB_3()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            // | ψ-> = 01と10の重ね合わせ状態(| 01 > - | 10 >) / sqrt(2)
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 3, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(0, 0);
            parser.GetQubit(0b01).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b10).Assert(-1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b11).Assert(0, 0);
        }

        [TestMethod]
        async public Task ProblemC_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemC.Driver.Run(sim, 1, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b0).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b1).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemC_2()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemC.Driver.Run(sim, 2, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b01).Assert(0, 0);
            parser.GetQubit(0b10).Assert(0, 0);
            parser.GetQubit(0b11).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemC_4()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestSummer2018Warmup.ProblemC.Driver.Run(sim, 4, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0).Assert(1.0 / Math.Sqrt(2), 0);
            for (int msk = 1; msk < 15; msk++)
            {
                parser.GetQubit(msk).Assert(0, 0);
            }
            parser.GetQubit(15).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemD_plus()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemD.Driver.Run(sim, 1, dumpPath);
            res.Should().Be(1);
        }

        [TestMethod]
        async public Task ProblemD_minus()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemD.Driver.Run(sim, -1, dumpPath);
            res.Should().Be(-1);
        }
    }
}
