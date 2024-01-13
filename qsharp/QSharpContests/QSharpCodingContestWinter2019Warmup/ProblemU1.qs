namespace QSharpContests.QSharpCodingContestWinter2019Warmup.ProblemU1 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[]) : Unit {
        ApplyToEach(X, qs);
    }

// }
// =============================================================================

    operation Driver (N : Int, dumppath : String) : Unit {
        QSharpContests.DumpUnitaryToFiles(N, Solve, dumppath);
    }
}
