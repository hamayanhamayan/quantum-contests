namespace QSharpContests {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation SetQubits (qs: Qubit[], bits: Bool[]) : Unit {
        for (i in 0..Length(bits)-1) {
            if (bits[i]) {
                X(qs[i]);
			}
		}
    }
}
