using Core.Formulas;
using Core.Formulas.Basic;

namespace Core.TruthAssignments
{
    public class FiniteAtomTruthAssignment : ITruthAssignment
    {
        public readonly string[] trueSymbols;
        public FiniteAtomTruthAssignment(params string[] trueSymbols)
        {
            this.trueSymbols = trueSymbols;
        }

        public bool Evaluate(Atom atom) => trueSymbols.Contains(atom.Symbol);
    }
}
