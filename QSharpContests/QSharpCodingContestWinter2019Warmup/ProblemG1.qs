namespace QSharpContests.QSharpCodingContestWinter2019Warmup.ProblemG1 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (x : Qubit[], y : Qubit) : Unit is Adj {
        Controlled X(x, y);
    }

// }
// =============================================================================

    operation Driver (bits : Bool[], dumppath : String) : Bool {
        using (qs = Qubit[Length(bits)]) {
            using (q = Qubit()) {
                QSharpContests.SetQubits(qs, bits);
                Solve(qs, q);
                mutable res = true;
                if (M(q) == Zero) {
                    set res = false;
                }
                DumpMachine(dumppath);
                Reset(q);
                ResetAll(qs);
                return res;
            }
        }
    }
}
