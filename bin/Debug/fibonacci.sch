ganzzahl n;
ganzzahl t = 0;
ganzzahl _t = 1;
ganzzahl kov = 0;

eingangspfad "fibonacci.in";
eingang n;
ganzzahl i = 1;
solange i < n + 1:
	wenn i ist 1:
		schreiben t,
		schreiben " ",
		i = i + 1,
	wenn i ist 2:
		schreiben _t,
		schreiben " ",
		i = i + 1,
	kov = t + _t,
	t = _t,
	_t = kov,

	schreiben kov,
	schreiben " ",
	i = i + 1,
schlafen;