namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemI {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (N : Int, Uf : ((Qubit[], Qubit) => Unit)) : Bool
    {
        using (x = Qubit[N]) {
            using (y = Qubit()) {
                X(y);

                for (i in 0..N-1) {
                    H(x[i]);
                }
                H(y);

                Uf(x, y);

                for (i in 0..N-1) {
                    H(x[i]);
                }
                H(y);

                mutable ret = true;
                for (i in 0..N-1) {
                    if (M(x[i]) == One) {
                        set ret = false;
                    }
                }
                
                ResetAll(x);
                Reset(y);

                return ret;
            }
        }
    }

// }
// =============================================================================

    operation Constant (x : Qubit[], y : Qubit) : Unit {
        X(y);
    }

    operation Driver (ans : Bool, n : Int, dumppath : String) : Bool {
        mutable ret = true;

        if (ans) {
            return Solve(n, Constant);
        } else {
            return Solve(n, QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemH.Solve);
        }
    }
}
