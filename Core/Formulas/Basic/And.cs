using Core.TruthAssignments;

namespace Core.Formulas.Basic
{
    public class And : IFormula
    {
        public IFormula A;
        public IFormula B;
        public And(IFormula A, IFormula B)
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
}
