using Core.ExtensionMethods;
using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Disjunctions;
using Core.TruthAssignments;

namespace CoreTests
{
    public class IFormulaTests
    {
        [Fact]
        public void GetSymbols_RandomFormula_ReturnsEmptyIEnumerable()
        {
            var P = new Atom("P1");
            var R = new Atom("P2");
            var S = new Atom("P3");
            var f = P.Not().Or(R.And(S.Not())).Or(P.And(R.Not()));

            var result = f.GetSymbols().ToArray();
            var expected = new[] { "P1", "P2", "P3" };
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Evalueate_TrueAndTrue_ReturnsTrue()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.And(Q);
            var t = new FiniteAtomTruthAssignment("P1", "P2");

            var result = f.Evaluate(t);
            Assert.True(result);
        }

        [Fact]
        public void Evalueate_TrueAndFalse_ReturnsFalse()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.And(Q);
            var t = new FiniteAtomTruthAssignment("P1");

            var result = f.Evaluate(t);
            Assert.False(result);
        }

        [Fact]
        public void Evalueate_FlaseAndTrue_ReturnsFalse()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.And(Q);
            var t = new FiniteAtomTruthAssignment("P2");

            var result = f.Evaluate(t);
            Assert.False(result);
        }

        [Fact]
        public void Evalueate_FlaseAndFalse_ReturnsFalse()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.And(Q);
            var t = new FiniteAtomTruthAssignment();

            var result = f.Evaluate(t);
            Assert.False(result);
        }

        [Fact]
        public void Evalueate_TrueOrTrue_ReturnsTrue()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.Or(Q);
            var t = new FiniteAtomTruthAssignment("P1", "P2");

            var result = f.Evaluate(t);
            Assert.True(result);
        }

        [Fact]
        public void Evalueate_TrueOrFalse_ReturnsTrue()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.Or(Q);
            var t = new FiniteAtomTruthAssignment("P1");

            var result = f.Evaluate(t);
            Assert.True(result);
        }

        [Fact]
        public void Evalueate_FalseOrTrue_ReturnsTrue()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.Or(Q);
            var t = new FiniteAtomTruthAssignment("P2");

            var result = f.Evaluate(t);
            Assert.True(result);
        }

        [Fact]
        public void Evalueate_FalseOrFalse_ReturnsFalse()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.Or(Q);
            var t = new FiniteAtomTruthAssignment();

            var result = f.Evaluate(t);
            Assert.False(result);
        }

        [Fact]
        public void Evalueate_NotTrue_ReturnsFalse()
        {
            var P = new Atom("P1");

            var f = P.Not();
            var t = new FiniteAtomTruthAssignment("P1");

            var result = f.Evaluate(t);
            Assert.False(result);
        }

        [Fact]
        public void Evalueate_NotFalse_ReturnsTrue()
        {
            var P = new Atom("P1");

            var f = P.Not();
            var t = new FiniteAtomTruthAssignment();

            var result = f.Evaluate(t);
            Assert.True(result);
        }


    }
}
