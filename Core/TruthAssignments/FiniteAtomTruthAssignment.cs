using Core.Formulas;
namespace Core.TruthAssignments
{
    public class FiniteAtomTruthAssignment : ITruthAssignment
    {
        public readonly string[] trueSymbols;
        public FiniteAtomTruthAssignment(string[] trueSymbols)
        {
            this.trueSymbols = trueSymbols;
        }

        public bool Evaluate(Atom atom) => trueSymbols.Contains(atom.Symbol);
    }
}
