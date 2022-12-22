using Core.TruthAssignments;

namespace Core.Formulas.Basic
{
    public class And : INonEmptyFormula
    {
        public INonEmptyFormula A;
        public INonEmptyFormula B;
        public And(INonEmptyFormula A, INonEmptyFormula B)
        {
            this.A = A;
            this.B = B;
        }

        public And(string A, string B)
        {
            this.A = new Atom(A);
            this.B = new Atom(B);
        }

        public bool Evaluate(ITruthAssignment T) => A.Evaluate(T) && B.Evaluate(T);

        public IEnumerable<string> GetSymbols() => A.GetSymbols().Union(B.GetSymbols());

    }

    public class And<T> : And where T : INonEmptyFormula
    {
        public new T A
        {
            get => (T)base.A;
            set
            {
                base.A = value;
            }
        }
        public new T B
        {
            get => (T)base.B;
            set
            {
                base.B = value;
            }
        }
        public And(T A, T B) : base(A, B)
        {
        }
    }
}
