namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemA1 {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Intrinsic;

    operation Solve (unitary : (Qubit => Unit is Adj+Ctl)) : Int {
        mutable ret = 0;
        using (q = Qubit()) {
            unitary(q);
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
            return Solve(X);
		}
    }
}
