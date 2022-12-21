using Core.ExtensionMethods;
using Core.Formulas.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTests
{
    public class GetEquivilandCNFTests
    {
        [Fact]
        public void LiteralOrLiteral_RetunsSame()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.Or(Q);

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void LiteralAndLiteral_RetunsSame()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var f = P.And(Q);

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void LiteralOrClause_RetunsSame()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");
            var f = P.Or(Q.Or(S));

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void ClauseOrLiteral_RetunsSame()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");
            var f = (Q.Or(S)).Or(P);

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }


        [Fact]
        public void ClauseConjunction_RetunsSame()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");
            var R = new Atom("P4");
            var f = P.Or(Q).Or(S).And(Q.Or(R.Not()));

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void NotAtom_RetunsSame()
        {
            var P = new NotAtom("P1");

            var result = P.GetEquivilandCNF();
            var expected = P;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void NotAtomNonLiteral_RetunsSame()
        {
            var P = new Atom("P1");
            var f = P.Not();

            var result = f.GetEquivilandCNF();
            var expected = f;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void DoubleNotOfAtom_RetunsAtom()
        {
            var P = new Atom("P1");
            var f = P.Not().Not();

            var result = f.GetEquivilandCNF();
            var expected = P;

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void LiteralOrAnd_Distributes()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");
            var f = P.Or(Q.And(S));

            var result = f.GetEquivilandCNF();
            var expected = P.Or(Q).And(P.Or(S));

            Assert.True(result.SyntacticEquals(expected));
        }

        [Fact]
        public void AndOrLiteral_Distributes()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");
            var f = Q.And(S).Or(P);

            var result = f.GetEquivilandCNF();
            var expected = P.Or(Q).And(P.Or(S));

            Assert.True(result.SyntacticEquals(expected));
        }
    }
}
