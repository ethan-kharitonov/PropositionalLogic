using Core;
using Core.ExtensionMethods;
using Core.Formulas;
using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace CoreTests
{
    public class ClauseTests
    {
        [Fact]
        public void BuildClause_SinglePositiveLiteral_Createsliteral()
        {
            var P = new Atom("P1");
            var clause = IClause.Build(new ILiteral[] { P });

            Assert.True(clause.SyntacticEquals(P));

        }

        [Fact]
        public void BuildClause_SingleNegativeLiteral_CreatesLiteral()
        {
            var P = new NotAtom("P1");
            var clause = IClause.Build(new ILiteral[] { P });

            Assert.True(clause.SyntacticEquals(P));
        }

        [Fact]
        public void BuildClause_TwoLiterals_CreatesClauseWithTwoLiterals()
        {
            var P = new NotAtom("P1");
            var Q = new Atom("P2");

            var clause = IClause.Build(P, Q );

            var expected = P.Or(Q);

            Assert.True(clause.SyntacticEquals(expected));
        }

        [Fact]
        public void BuildClause_ThreeLiterals_CreatesClauseWithLiteralAndClause()
        {
            var P = new NotAtom("P1");
            var Q = new Atom("P2");
            var R = new Atom("P3");

            var clause = IClause.Build(new ILiteral[] { P, Q, R });
            var expected = P.Or(Q).Or(R);

            Assert.True(clause.SyntacticEquals(expected));

        }
    }
}