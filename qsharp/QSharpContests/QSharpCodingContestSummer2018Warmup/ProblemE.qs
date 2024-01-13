namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemE {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Ms (qs: Qubit[]) : Int
    {
        mutable ret = 0;
        mutable p = 1;
        for (i in 0..Length(qs) - 1) {
            if (M(qs[i]) == One) {
                set ret = ret + p;
            }
            set p = p * 2;
        }
        return ret;
    }

    operation Solve (qs : Qubit[]) : Int
    {
        CNOT(qs[0], qs[1]);
        H(qs[0]);
        return Ms(qs);
    }

// }
// =============================================================================

    operation Driver (index : Int, dumppath : String) : Int {
        using (qs = Qubit[2]) {
            QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB.Solve(qs, index);
            let res = Solve(qs);
            DumpMachine(dumppath);
            ResetAll(qs);
            return res;
        }
    }
}
