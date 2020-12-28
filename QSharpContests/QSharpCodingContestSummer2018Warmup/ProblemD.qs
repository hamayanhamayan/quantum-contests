namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemD {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (q : Qubit) : Int {
        H(q);
        if (M(q) == Zero) {
            return 1;
        }
        else {
            return -1;
        }
    }

// }
// =============================================================================

    operation Driver (sign : Int, dumppath : String) : Int {
        using (q = Qubit()) {
            if (sign == 1) {
                H(q);
            } else {
                X(q);
                H(q);
            }

            let res = Solve(q);
            DumpMachine(dumppath);
            Reset(q);
            return res;
        }
    }
}
