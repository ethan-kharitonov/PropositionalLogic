using Core.Formulas.Basic;
using Core.Formulas.Conjunctions.ILiteralConjunctions;

namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public interface IAndClauseDisjunction : IFormulaOrEmpty
    {
        public static IAndClauseDisjunction Build(params INonEmptyAndClauseDisjunction[] nonEmptyAndClauseDisjunctions)
        {
            if (nonEmptyAndClauseDisjunctions.Length == 0)
            {
                return EmptyDisjunction.Instance;
            }

            if (nonEmptyAndClauseDisjunctions.Length == 1)
            {
                return nonEmptyAndClauseDisjunctions[0];
            }

            return new AndClauseDisjunction(nonEmptyAndClauseDisjunctions);
        }
    }
}
