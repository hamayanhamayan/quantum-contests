using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;

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
            await QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, 1, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, -1, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 0, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 1, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 2, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemB.Driver.Run(sim, 3, dumpPath);
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
            await QSharpCodingContestSummer2018Warmup.ProblemC.Driver.Run(sim, 1, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b0).Assert(1.0 / Math.Sqrt(2), 0);
            parser.GetQubit(0b1).Assert(1.0 / Math.Sqrt(2), 0);
        }

        [TestMethod]
        async public Task ProblemC_2()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestSummer2018Warmup.ProblemC.Driver.Run(sim, 2, dumpPath);
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

        [TestMethod]
        async public Task ProblemE_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemE.Driver.Run(sim, 0, dumpPath);
            res.Should().Be(0);
        }

        [TestMethod]
        async public Task ProblemE_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemE.Driver.Run(sim, 1, dumpPath);
            res.Should().Be(1);
        }

        [TestMethod]
        async public Task ProblemE_2()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemE.Driver.Run(sim, 2, dumpPath);
            res.Should().Be(2);
        }

        [TestMethod]
        async public Task ProblemE_3()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemE.Driver.Run(sim, 3, dumpPath);
            res.Should().Be(3);
        }

        [TestMethod]
        async public Task ProblemF_pat1()
        {
            int ans = 0;
            var bits0 = new QArray<bool>(new bool[] { true, false, true });
            var bits1 = new QArray<bool>(new bool[] { true, false, false });

            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemF.Driver.Run(sim, ans, bits0, bits1, dumpPath);
            res.Should().Be(ans);
        }

        [TestMethod]
        async public Task ProblemF_pat2()
        {
            int ans = 1;
            var bits0 = new QArray<bool>(new bool[] { false, true, true, false });
            var bits1 = new QArray<bool>(new bool[] { true, false, false, true });

            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemF.Driver.Run(sim, ans, bits0, bits1, dumpPath);
            res.Should().Be(ans);
        }

        [TestMethod]
        async public Task ProblemF_pat3()
        {
            int ans = 1;
            var bits0 = new QArray<bool>(new bool[] { false });
            var bits1 = new QArray<bool>(new bool[] { true });

            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long res = await QSharpCodingContestSummer2018Warmup.ProblemF.Driver.Run(sim, ans, bits0, bits1, dumpPath);
            res.Should().Be(ans);
        }

        [TestMethod]
        async public Task ProblemG_0()
        {
            int n = 4, k = 0;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestSummer2018Warmup.ProblemG.Driver.Run(sim, n, k, dumpPath);
            
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetProb(k, false).Should().BeApproximately(1, Modules.EPS);
            parser.GetProb(n, false).Should().BeApproximately(1, Modules.EPS);
        }

        [TestMethod]
        async public Task ProblemH_0()
        {
            var bits = new QArray<bool>(new bool[] { false, false, true });
            int cnt = 0;
            foreach (var bit in bits)
            {
                if (bit) cnt++;
            }
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long parity = await QSharpCodingContestSummer2018Warmup.ProblemH.Driver.Run(sim, bits, dumpPath);
            parity.Should().Be(cnt % 2);
        }

        [TestMethod]
        async public Task ProblemI_constant()
        {
            bool expect = false;
            int n = 5;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool actual = await QSharpCodingContestSummer2018Warmup.ProblemI.Driver.Run(sim, expect, n, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemI_balanced()
        {
            bool expect = true;
            int n = 5;
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            bool actual = await QSharpCodingContestSummer2018Warmup.ProblemI.Driver.Run(sim, expect, n, dumpPath);
            actual.Should().Be(expect);
        }
    }
}
