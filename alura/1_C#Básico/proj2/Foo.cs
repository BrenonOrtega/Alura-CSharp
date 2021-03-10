using System;

namespace proj2{
    public class Foo{
        public Foo(string bar, int inteiro) {
            this.Bar = bar;
            this.BarBaz = Bar+Baz;
            this.Inteiro = QuadradoInteiro(inteiro);
        }
        public string Bar;
        public string Baz = "baz";
        public string BarBaz;
        public int Inteiro { get; private set; }

        private int QuadradoInteiro(int inteiro)        {
            return inteiro % 2 == 0 ? (int) Math.Pow(inteiro, 2) : 0;
        }
    }
}
