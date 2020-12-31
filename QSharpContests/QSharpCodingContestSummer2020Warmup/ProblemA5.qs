namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemA5 {
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Intrinsic;

    operation Solve (unitary : (Qubit => Unit is Adj+Ctl)) : Int {
        mutable ret = 0;
        using (qs = Qubit[2]) {
            H(qs[0]);
            Controlled unitary([qs[0]], qs[1]);
            H(qs[0]);
            if (M(qs[0]) == One) {
                set ret = 1;
            }
            ResetAll(qs);
            return ret;
        }
    }

// }
// =============================================================================

    operation NegativeZ (q : Qubit) : Unit is Adj+Ctl {
        Ry(2.0 * ArcCos(-1.0), q);
    }

    operation Driver (ans : Int, dumppath : String) : Int {
        if (ans == 0) {
            return Solve(Z);
        }
        else {
            return Solve(NegativeZ);
        }
    }
}
