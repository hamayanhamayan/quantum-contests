namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemA4 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Intrinsic;

    operation Solve (unitary : (Qubit[] => Unit is Adj+Ctl)) : Int {
        mutable ret = 0;
        using (qs = Qubit[2]) {
            unitary(qs);

            if (M(qs[1]) == Zero) {
                set ret = 1;
			}

            ResetAll(qs);
            return ret;
		}
    }

// }
// =============================================================================

    operation IX (qs : Qubit[]) : Unit is Adj+Ctl {
        X(qs[1]);
    }

    operation CNOTWrapper (qs : Qubit[]) : Unit is Adj+Ctl {
        CNOT(qs[0], qs[1]);
    }

    operation Driver (ans : Int, dumppath : String) : Int {
        if (ans == 0) {
            return Solve(IX);
		}
        else {
            return Solve(CNOTWrapper);
		}
    }
}
