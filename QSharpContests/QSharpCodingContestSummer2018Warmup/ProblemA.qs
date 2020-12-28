namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemA {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (q : Qubit, sign : Int) : Unit {
        if (sign == -1) {
            X(q);
        }
        H(q);
    }

// }
// =============================================================================

    operation Driver (sign : Int, dumppath : String) : Unit {
        using (q = Qubit()) {
            Solve(q, sign);
            DumpMachine(dumppath);
            Reset(q);
        }
    }
}
