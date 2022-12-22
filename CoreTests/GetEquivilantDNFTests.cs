using Core.ExtensionMethods;
using Core.Formulas.Basic;
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
            Assert.True(result.SyntacticEquals(EmptyDisjunction.Instance));
        }
    }
}
