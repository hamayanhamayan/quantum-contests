namespace QSharpContests.QSharpCodingContestSummer2018Warmup.ProblemF {
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (qs : Qubit[], bits0 : Bool[], bits1 : Bool[]) : Int
    {
        for (i in 0..Length(bits0)-1) {
            let boolean = (M(qs[i]) == One);
            if (bits0[i] != boolean) {
                return 1;
            }
        }
        return 0;
    }

// }
// =============================================================================

    operation Driver (ans : Int, bits0 : Bool[], bits1 : Bool[], dumppath : String) : Int {
        using (qs = Qubit[Length(bits0)]) {
            if (ans == 0) {
                for (i in 0..Length(bits0)-1) {
                    if (bits0[i]) {
                        X(qs[i]);
                    }
                }
            } else {
                for (i in 0..Length(bits1)-1) {
                    if (bits1[i]) {
                        X(qs[i]);
                    }
                }
            }

            let res = Solve(qs, bits0, bits1);
            DumpMachine(dumppath);
            ResetAll(qs);
            return res;
        }
    }
}
