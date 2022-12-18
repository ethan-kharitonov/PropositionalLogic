using Core.TruthAssignments;

namespace Core.Formulas.Basic
{
    public interface IFormula : IFormulaOrEmpty
    {
        public abstract bool Evaluate(ITruthAssignment T);
        public abstract IEnumerable<string> GetSymbols();
    }
}
