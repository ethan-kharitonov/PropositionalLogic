using Core.ExtensionMethods;
using Core.TruthAssignments;

namespace Core.Formulas.Basic
{
    public class Not : INonEmptyFormula
    {
        public INonEmptyFormula A;
        public Not(INonEmptyFormula A)
        {
            this.A = A;
        }

        public Not(string A)
        {
            this.A = new Atom(A);
        }

        public bool Evaluate(ITruthAssignment T) => !A.Evaluate(T);

        public IEnumerable<string> GetSymbols() => A.GetSymbols();

        public IFormula PushNegationInsideIfPossile()
        {
            if (A is And and)
            {
                var p = and.A.Not().RemoveDoubleNegationIfExists();
                var q = and.B.Not().RemoveDoubleNegationIfExists();
                return p.Or(q);
            }

            if (A is Or or)
            {
                var p = or.A.Not().RemoveDoubleNegationIfExists();
                var q = or.B.Not().RemoveDoubleNegationIfExists();
                return p.And(q);
            }

            return this;
        }

        public INonEmptyFormula RemoveDoubleNegationIfExists() => A is Not inner ? inner.A : this;
    }

    public class Not<T> : Not where T : INonEmptyFormula
    {
        public new T A
        {
            get => (T)base.A;
            set
            {
                base.A = value;
            }
        }
        public Not(T A) : base(A)
        {
        }
    }
}
