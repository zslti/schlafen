ganzzahl num = 121;
ganzzahl rev = 0;
ganzzahl rem;
ganzzahl temp = num;

solange temp > 0:
	rem = temp % 10,
	rev = rev * 10 + rem,
	temp = temp / 10,
;
wenn rev ist num:
	schreiben "palindrom",
;
wenn rev ist nicht num:
	schreiben "nem palindrom",
schlafen;