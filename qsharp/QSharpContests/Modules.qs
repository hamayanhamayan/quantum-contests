namespace QSharpContests {

    open Microsoft.Quantum.Arithmetic;
    open Microsoft.Quantum.Diagnostics;
    open Microsoft.Quantum.Convert;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation SetQubits (qs: Qubit[], bits: Bool[]) : Unit {
        for (i in 0..Length(bits)-1) {
            if (bits[i]) {
                X(qs[i]);
			}
		}
    }

    // https://github.com/microsoft/QuantumKatas/blob/master/utilities/DumpUnitary/Operations.qs
    operation DumpUnitaryToFiles (N : Int, unitary : (Qubit[] => Unit), dumpFilePostfix: String) : Unit {
        let size = 1 <<< N;
        
        using (qs = Qubit[N]) {
            for (k in 0 .. size - 1) {                
                // Prepare k-th basis vector
                let binary = IntAsBoolArray(k, N);
                
                //Message($"{k}/{N} = {binary}");
                // binary is little-endian notation, so the second vector tried has qubit 0 in state 1 and the rest in state 0
                ApplyPauliFromBitString(PauliX, true, binary, qs);
                
                // Apply the operation
                unitary(qs);
                
                // Dump the contents of the k-th column
                DumpMachine($"{k}_{dumpFilePostfix}");
                
                ResetAll(qs);
            }
        }
    }

    operation ParseInt(le: LittleEndian) : Int {
        mutable ret = 0;
        mutable p = 1;
        let qs = le!;

        for (i in 0..Length(qs)-1) {
            if (M(qs[i]) == One) {
                set ret = ret + p;
			}
            set p = p * 2;
		}

        return ret;
	}
}
