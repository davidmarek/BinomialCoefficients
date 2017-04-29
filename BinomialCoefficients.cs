using System;

public class BinomialCoefficients {
	const int MAX = 1000000007;
	
	static int add(int a, int b){
		return (a + b) % MAX;
	}
	
	static int mul(int a, int b){
		return (int)(((long)a * b) % MAX);
	}
	
	static int powMod(int a, int b){
		int res = 1;
		for (; b > 0; b >>= 1){
			if ((b & 1) > 0) res = mul(res, a);
			a = mul(a, a);
		}
		return res;
	}
	
	static int modInverse(int a){
		return powMod(a, MAX - 2);
	}
	
	static int fact(int n) {
		if (n <= 1) {
			return 1;
		} else {
			return mul(n, fact(n-1));
		}
	}
	
	static int invfact(int n) {
		return modInverse(fact(n));
	}
	
	static int C(int n, int k){
		return n < k ? 0 : mul(fact(n), mul(invfact(k), invfact(n-k)));
	}
}
		
