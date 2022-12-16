using Core;
using Core.Formulas;

namespace CoreTests
{
    public class DisplayExtensionTests
    {
        private const string latexNot = DisplayExtentions.LatexNot;
        private const string latexAnd = DisplayExtentions.LatexAnd;
        private const string latexOr = DisplayExtentions.LatexOr;

        [Fact]
        public void ToLatex_Atom_DisplaysSymbol()
        {
            var P = new Atom("P1");
            Assert.Equal("P1", P.ToLatex());
        }

        [Fact]
        public void ToLatex_NotAtom_DisplaysNotSymbol()
        {
            var A = new Not("P1");
            Assert.Equal($"{latexNot} P1", A.ToLatex());
        }

        [Fact]
        public void ToLatex_AndTwoAtoms_DisplaysAndSymbol()
        {
            var A = new And("P1", "P2");
            Assert.Equal($"(P1 {latexAnd} P2)", A.ToLatex());
        }

        [Fact]
        public void ToLatex_OrTwoAtoms_DisplaysOrSymbol()
        {
            var A = new Or("P1", "P2");
            Assert.Equal($"(P1 {latexOr} P2)", A.ToLatex());
        }

        [Fact]
        public void ToLatex_Nested_DisplaysCorrectLatex()
        {
            var A = new And("P1", "P2").Or(new Not("P3")).Not();
            Assert.Equal($"{latexNot} ((P1 {latexAnd} P2) {latexOr} {latexNot} P3)", A.ToLatex());
        }

        [Fact]
        public void ToLatex_Nested2_DisplaysCorrectLatex()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");

            var f = new And(P, new Or(Q, new Not(S)));

            Assert.Equal($"(P1 {latexAnd} (P2 {latexOr} {latexNot} P3))", f.ToLatex());
        }
    }

    
}
