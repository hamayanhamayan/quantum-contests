namespace QSharpContests.QSharpCodingContestSummer2020Warmup.ProblemC {
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Diagnostics;

// =============================================================================
// namespace Solution {

    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Measurement;

    operation Solve (qs : Qubit[]) : Unit {
        using (ancilla = Qubit()) {
            repeat {
                ApplyToEach(H, qs);
                (ControlledOnInt(0,X))(qs, ancilla);
                let ret = MResetZ(ancilla);
            }
            until (ret == Zero)
            fixup {
                ResetAll(qs);
            }
        }
    }

// }
// =============================================================================

    operation Driver (dumppath : String) : Unit {
        using (qs = Qubit[2]) {
            Solve(qs);
            DumpMachine(dumppath);
            ResetAll(qs);
        }
    }
}
