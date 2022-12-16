using Core;
using Core.ExtensionMethods;
using Core.Formulas;
using Core.Formulas.Basic;

namespace CoreTests
{
    public class OrTests
    {
        [Fact]
        public void Distribute_AtomOrAnd_Distributes()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");

            var f = P.Or(Q.And(S)).Distribute();
            var expected = P.Or(Q).And(P.Or(S));

            Assert.True(f.SyntacticEquals(expected));
        }

        [Fact]
        public void Distribute_AndOrAtom_Distributes()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");

            var f = Q.And(S).Or(P).Distribute();
            var expected = P.Or(Q).And(P.Or(S));

            Assert.True(f.SyntacticEquals(expected));
        }
    }
}
