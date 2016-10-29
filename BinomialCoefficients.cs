using System;

public class BinomialCoefficients {
	private int[] _factorials;
	private int[] _inverseFactorials;
	private int _modulo;
	private int _maxValue;
	
	public BinomialCoefficients(int modulo, int maxValue) {
		_modulo = modulo;
		_maxValue = maxValue;
		_factorials = new int[maxValue + 1];
		_inverseFactorials = new int[maxValue + 1];
		
		Generate();		
	}
	
	public int C(int n, int k) {
		if (n < k) {
			return 0;
		} else {
			return Mul(_factorials[n], Mul(_inverseFactorials[k], _inverseFactorials[n - k]));
		}
	}
	
	private void Generate() {
		_factorials[0] = _inverseFactorials[0] = 1;
		for (int i = 1; i <= _maxValue; i++) {
			_factorials[i] = Mul(_factorials[i-1], i);
			_inverseFactorials[i] = InverseMod(_factorials[i]);
		}
	}
	
	private int Add(int a, int b) {
		return (a + b) % _modulo;
	}
	
	private int Mul(int a, int b) {
		return (int)(((long)a * b) % _modulo);
	}
	
	private int PowerMod(int a, int b) {
		int res = 1;
		for (; b > 0; b /= 2) {
			if (b % 2 == 1) {
				res = Mul(res, a);
			}
			a = Mul(a, a);
		}
		return res;
	}
	
	private int InverseMod(int a) {
		return PowerMod(a, _modulo - 2);
	}
}
		
