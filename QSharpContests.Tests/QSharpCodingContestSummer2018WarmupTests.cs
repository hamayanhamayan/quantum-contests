using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Quantum.Simulation.Simulators;
using System.Threading.Tasks;

namespace QSharpContests.Tests
{
    [TestClass]
    public class QSharpCodingContestSummer2018WarmupTests
    {
        [TestMethod]
        async public Task ProblemA()
        {
            string dumpPath = Modules.GetTempFilepath();

            // |+>
            using (var sim = new QuantumSimulator())
            {
                await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, 1, dumpPath);
                DumpMachineParser parser = new DumpMachineParser(dumpPath);
                parser.GetQubit(0b0).Assert(0.707106781, 0);
                parser.GetQubit(0b1).Assert(0.707106781, 0);
            }

            // |->
            using (var sim = new QuantumSimulator())
            {
                await QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemA.Driver.Run(sim, -1, dumpPath);
                DumpMachineParser parser = new DumpMachineParser(dumpPath);
                parser.GetQubit(0b0).Assert(0.707106781, 0);
                parser.GetQubit(0b1).Assert(-0.707106781, 0);
            }
        }
    }
}
