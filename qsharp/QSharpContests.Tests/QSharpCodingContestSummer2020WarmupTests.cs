using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;

using System.Threading.Tasks;
using System;

using FluentAssertions;

namespace QSharpContests.Tests
{
    [TestClass]
    public class QSharpCodingContestSummer2020WarmupTests
    {
        [TestMethod]
        async public Task ProblemA1_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 0;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA1.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA1_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA1.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA2_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 0;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA2.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA2_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA2.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA3_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 0;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA3.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA3_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA3.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA4_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 0;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA4.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA4_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA4.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA5_0()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 0;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA5.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemA5_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemA5.Driver.Run(sim, expect, dumpPath);
            actual.Should().Be(expect);
        }

        [TestMethod]
        async public Task ProblemB1_1()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 1;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemB1.Driver.Run(sim, expect, 4, dumpPath);
            actual.Should().Be(expect + 1);
        }

        [TestMethod]
        async public Task ProblemB2_4()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            long expect = 4;
            long actual = await QSharpCodingContestSummer2020Warmup.ProblemB2.Driver.Run(sim, expect, 4, dumpPath);
            actual.Should().Be(expect - 1);
        }

        [TestMethod]
        async public Task ProblemC()
        {
            string dumpPath = Modules.GetTempFilepath();
            using var sim = new QuantumSimulator();
            await QSharpCodingContestSummer2020Warmup.ProblemC.Driver.Run(sim, dumpPath);
            DumpMachineParser parser = new DumpMachineParser(dumpPath);
            parser.GetQubit(0b00).Assert(0.0, 0.0);
            parser.GetQubit(0b01).Assert(1.0 / Math.Sqrt(3), 0.0);
            parser.GetQubit(0b10).Assert(1.0 / Math.Sqrt(3), 0.0);
            parser.GetQubit(0b11).Assert(1.0 / Math.Sqrt(3), 0.0);
        }
    }
}
