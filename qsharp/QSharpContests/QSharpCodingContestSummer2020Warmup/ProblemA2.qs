namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemA2 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Intrinsic;

    operation Solve (unitary : (Qubit => Unit is Adj+Ctl)) : Int {
        mutable ret = 0;
        using (q = Qubit()) {
            H(q);
            unitary(q);
            H(q);
            if (M(q) == One) {
                set ret = 1;
			}
            Reset(q);
            return ret;
		}
    }

// }
// =============================================================================

    operation Driver (ans : Int, dumppath : String) : Int {
        if (ans == 0) {
            return Solve(I);
		}
        else {
            return Solve(Z);
		}
    }
}
