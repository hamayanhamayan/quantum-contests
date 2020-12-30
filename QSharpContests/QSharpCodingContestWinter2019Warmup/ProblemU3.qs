namespace QSharpContests.QSharpCodingContestWinter2019Warmup.ProblemU3 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[]) : Unit {
        let N = Length(qs);
        for (i in 0..N-2) {
            X(qs[i]);
            Controlled H([qs[N-1]], qs[i]);
		}
    }

// }
// =============================================================================

    operation Driver (N : Int, dumppath : String) : Unit {
        QSharpContests.DumpUnitaryToFiles(N, Solve, dumppath);
    }
}
