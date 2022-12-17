using Core.ExtensionMethods;
using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Disjunctions;

namespace CoreTests
{
    public class GetEquivilantDNFTests
    {
        [Fact]
        public void UnsatisfiableFormula_ReturnsEmptyDisjunction()
        {
            var P = new Atom("P1");
            var f = P.And(P.Not());

            var result = f.GetEquivilantDNF();
            var expected = EmptyDisjunction.Instance;

            Assert.True(result.SyntacticEquals(expected));
        }
    }
}
