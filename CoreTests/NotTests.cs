using Core;
using Core.ExtensionMethods;
using Core.Formulas;
using Core.Formulas.Basic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace CoreTests
{
    public class NotTests
    {
        [Fact]
        public void PushNegationInside_NegatingAndTwoAtoms_ReturnsOrOfNegativeLiterals()
        {
            var f = new Atom("P1").And("P2").Not();
            var s = f.PushNegationInside();

            var or = Assert.IsType<Or>(s);

            var not1 = Assert.IsType<Not>(or.A);
            var not2 = Assert.IsType<Not>(or.B);

            Assert.IsType<Atom>(not1.A);
            Assert.IsType<Atom>(not2.A);
        }

        [Fact]
        public void PushNegationInside_NegatingOrTwoNotAtoms_ReturnsOrOfNegativeLiterals()
        {
            var f = new NotAtom("P1").Or(new NotAtom("P2")).Not();
            var s = f.PushNegationInside();

            var or = Assert.IsType<And>(s);

            Assert.IsType<Atom>(or.A);
            Assert.IsType<Atom>(or.B);
        }

        [Fact]
        public void PushNegationInside_NegatingOrTwoAtoms_ReturnsOrOfNegativeLiterals()
        {
            var f = new Atom("P1").Or("P2").Not();
            var s = f.PushNegationInside();

            var or = Assert.IsType<And>(s);

            var not1 = Assert.IsType<Not>(or.A);
            var not2 = Assert.IsType<Not>(or.B);

            Assert.IsType<Atom>(not1.A);
            Assert.IsType<Atom>(not2.A);
        }

        [Fact]
        public void PushNegationInside_NegatingAndTwoNotAtoms_ReturnsOrOfNegativeLiterals()
        {
            var f = new NotAtom("P1").And(new Not("P2")).Not();
            var s = f.PushNegationInside();

            var or = Assert.IsType<Or>(s);

            Assert.IsType<Atom>(or.A);
            Assert.IsType<Atom>(or.B);
        }

        [Fact]
        public void RemoveDoubleNegationIfExists_NegationExists_NegationIsRemoved()
        {
            var f = new Not("P1").Not();
            Assert.IsType<Atom>(f.RemoveDoubleNegationIfExists());
        }

        [Fact]
        public void RemoveDoubleNegationIfExists_NotAtom_NegationIsRemoved()
        {
            var f = new NotAtom("P1").Not();
            Assert.IsType<Atom>(f.RemoveDoubleNegationIfExists());
        }

        [Fact]
        public void RemoveDoubleNegationIfExists_ThreeNots_OneNotLeft()
        {
            var P = new Atom("P1");

            var f = P.Not().Not().Not();
            var s = f.RemoveDoubleNegationIfExists();
            var expected = P.Not();
            
            Assert.True(s.SyntacticEquals(expected));
        }

        [Fact]
        public void RemoveDoubleNegationIfExists_NegatedNotAtom_OneNotLeft()
        {
            var f = new NotAtom("P1").Not();
            Assert.IsType<Atom>(f.RemoveDoubleNegationIfExists());
        }
    }
}
