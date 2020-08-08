namespace Quantum.QRNGGUI {

    open Microsoft.Quantum.Convert;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Measurement;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;

    operation makeQubit() : Result {
        using (q = Qubit()) {
            H(q);
            return MResetZ(q);
		}
	}

    operation QRNG(max : Int) : Int {
        mutable bits = new Result[0];
        for (i in 1..BitSizeI(max)) {
            set bits += [makeQubit()];  
		}
        let sample = ResultArrayAsInt(bits);
        return sample > max ? QRNG(max) | sample;
	}
}
