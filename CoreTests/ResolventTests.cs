using Core.ExtensionMethods;
using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace CoreTests
{
    public class ResolventTests
    {
        [Fact]
        public void GetResolventWith_LiteralAndNegationOfThatLiteral_RetrunsEmptyClause()
        {
            INonEmptyClause P = new Atom("P1");

            var result = P.GetResolventWith(new NotAtom("P1"));
            var expected = EmptyDisjunction.Instance;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetResolventWith_Random_RetrunsResolvent()
        {
            INonEmptyClause P = new Atom("P1");
            INonEmptyClause Q = new NotAtom("P2");
            INonEmptyClause R = new Atom("P3");
            INonEmptyClause S = new Atom("P4");

            INonEmptyClause c1 = new Clause(P, Q, R);
            INonEmptyClause c2 = new Clause(S, new NotAtom("P3"));

            var result = c1.GetResolventWith(c2);
            var expected = new Clause(P, Q, S);

            Assert.True(result.SyntacticEquals(expected));

        }
    }
}
