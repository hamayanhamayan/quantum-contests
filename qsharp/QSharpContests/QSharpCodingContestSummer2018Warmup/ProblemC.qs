namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemC {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[]) : Unit {
        H(qs[0]);
        for (i in 1..Length(qs)-1) {
            CNOT(qs[0], qs[i]);
        }
    }

// }
// =============================================================================

    operation Driver (num : Int, dumppath : String) : Unit {
        using (qs = Qubit[num]) {
            Solve(qs);
            DumpMachine(dumppath);
            ResetAll(qs);
        }
    }
}
