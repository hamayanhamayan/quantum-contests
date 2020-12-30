namespace QSharpContests.QSharpCodingContestWinter2019Warmup.ProblemU2 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[]) : Unit {
        ApplyToEach(H, qs);
        if (Length(qs) != 1) {
            H(qs[1]);
		}
    }

// }
// =============================================================================

    operation Driver (N : Int, dumppath : String) : Unit {
        QSharpContests.DumpUnitaryToFiles(N, Solve, dumppath);
    }
}
