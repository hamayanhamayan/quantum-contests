namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemB2 {
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Arithmetic;
    open Microsoft.Quantum.Intrinsic;

    operation Solve (register : LittleEndian) : Unit is Adj+Ctl {
        let qs = register!;
        let N = Length(qs);

        if (1 < N) {
            X(qs[0]);
            Controlled Solve(qs[0..0], LittleEndian(qs[1..N-1]));
            X(qs[0]);
        }

        X(qs[0]);
    }

// }
// =============================================================================

    operation Driver (x : Int, bit : Int, dumppath : String) : Int {
        using (input = Qubit[bit+1]) {
            let le = LittleEndian(input);
            ApplyXorInPlace(x, le);
            Solve(le);
            let ret = QSharpContests.ParseInt(le);
            ResetAll(input);
            return ret;
        }
    }
}
