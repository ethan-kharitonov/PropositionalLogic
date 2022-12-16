using Core.TruthAssignments;

namespace Core.Formulas
{
    public interface IFormula
    {
        public abstract bool Evaluate(ITruthAssignment T);
        public abstract IEnumerable<string> GetSymbols();
    }
}
