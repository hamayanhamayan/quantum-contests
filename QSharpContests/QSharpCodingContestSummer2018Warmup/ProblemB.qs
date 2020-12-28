namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemB {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[], index : Int) : Unit
    {
        if (index == 0) {
            H(qs[0]);
            CNOT(qs[0], qs[1]);
        }
        elif (index == 1)
        {
            X(qs[0]);
            H(qs[0]);
            CNOT(qs[0], qs[1]);
        }
        elif (index == 2)
        {
            H(qs[0]);
            CNOT(qs[0], qs[1]);
            X(qs[0]);
        }
        elif (index == 3)
        {
            X(qs[0]);
            H(qs[0]);
            CNOT(qs[0], qs[1]);
            X(qs[0]);
        }
    }

// }
// =============================================================================

    operation Driver (index : Int, dumppath : String) : Unit {
        using (qs = Qubit[2]) {
            Solve(qs, index);
            DumpMachine(dumppath);
            ResetAll(qs);
        }
    }
}
