using Core;
using Core.ExtensionMethods;
using Core.Formulas;
using Core.Formulas.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTests
{
    public class SyntacticEqualsTests
    {
        [Fact]
        public void TwoEqualAtoms_Equals()
        {
            var P = new Atom("P1");
            var Q = new Atom("P1");

            Assert.True(P.SyntacticEquals(Q));
        }

        [Fact]
        public void TwoEqualNotAtoms_Equals()
        {
            var P = new NotAtom("P1");
            var Q = new NotAtom("P1");

            Assert.True(P.SyntacticEquals(Q));
        }

        [Fact]
        public void NotAtomLiteralComparedToNotAtomNonLiteral_Equals()
        {
            var P = new NotAtom("P1");
            var Q = new Not("P1");

            Assert.True(P.SyntacticEquals(Q));
        }

        [Fact]
        public void And_Equals()
        {
            var P = new Atom("P1");
            var Q = new Atom("P1");
            var f = P.And(Q);

            Assert.True(f.SyntacticEquals(f));
        }

        [Fact]
        public void Or_Equals()
        {
            var P = new Atom("P1");
            var Q = new Atom("P1");
            var f = P.Or(Q);

            Assert.True(f.SyntacticEquals(f));
        }

        [Fact]
        public void Nested_Equals()
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");

            var f = P.And(S.Not()).Or(Q.Not().Not());
            Assert.True(f.SyntacticEquals(f));
        }
    }
}
