namespace QSharpContests.QSharpCodingContestWinter2019Warmup.ProblemG3 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (x : Qubit[], y : Qubit) : Unit is Adj {
        let n = Length(x);
        using (qs = Qubit[n/2]) {
            for (i in 0..n/2-1) {
                CNOT(x[i], qs[i]);
                CNOT(x[n-1-i], qs[i]);
                X(qs[i]);
			}

            Controlled X(qs, y);

            for (i in 0..n/2-1) {
                X(qs[i]);
                CNOT(x[n-1-i], qs[i]);
                CNOT(x[i], qs[i]);
			}
		}
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
