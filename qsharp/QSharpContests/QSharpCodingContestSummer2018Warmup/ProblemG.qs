namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemG {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (x : Qubit[], y : Qubit, k : Int) : Unit
    {
        CNOT(x[k], y);
    }

// }
// =============================================================================

    operation Driver (n: Int, k : Int, dumppath : String) : Unit {
        using (qs = Qubit[n]) {
            using (q = Qubit()) {
                Solve(qs, q, k);
                DumpMachine(dumppath);
                Reset(q);
                ResetAll(qs);
            }
        }
    }
}
