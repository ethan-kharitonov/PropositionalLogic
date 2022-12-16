using Core.TruthAssignments;
namespace Core.Formulas
{
    public class Or : IFormula
    {
        public IFormula A;
        public IFormula B;
        public Or(IFormula A, IFormula B)
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

        public IFormula Distribute()
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
}
