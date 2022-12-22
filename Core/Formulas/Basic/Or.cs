using Core.ExtensionMethods;
using Core.TruthAssignments;

namespace Core.Formulas.Basic
{
    public class Or : INonEmptyFormula
    {
        public INonEmptyFormula A;
        public INonEmptyFormula B;
        public Or(INonEmptyFormula A, INonEmptyFormula B)
        {
            this.A = A;
            this.B = B;
        }

        public Or(string A, string B)
        {
            this.A = new Atom(A);
            this.B = new Atom(B);
        }

        public bool Evaluate(ITruthAssignment T) => A.Evaluate(T) || B.Evaluate(T);

        public IEnumerable<string> GetSymbols() => A.GetSymbols().Union(B.GetSymbols());

        public INonEmptyFormula Distribute()
        {
            if (B is And and)
            {
                var c1 = A.Or(and.A);
                var c2 = A.Or(and.B);
                return c1.And(c2);
            }

            if (A is And)
            {
                return new Or(B, A).Distribute();
            }

            return this;
        }
    }

    public class Or<T> : Or where T : INonEmptyFormula
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
        public Or(T A, T B) : base(A, B)
        {
        }
    }
}
