namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemH {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (x : Qubit[], y : Qubit) : Unit
    {
        for (i in 0..Length(x)-1) {
            CNOT(x[i], y);
        }
    }

// }
// =============================================================================

    operation Driver (bits : Bool[], dumppath : String) : Int {
        using (qs = Qubit[Length(bits)]) {
            using (q = Qubit()) {
                QSharpContests.SetQubits(qs, bits);
                Solve(qs, q);
                mutable res = 1;
                if (M(q) == Zero) {
                    set res = 0;
                }
                DumpMachine(dumppath);
                Reset(q);
                ResetAll(qs);
                return res;
            }
        }
    }
}
