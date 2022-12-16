using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.ILiteralConjunctions;

namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public interface IAndClauseDisjunction : IFormula
    {
        public static IAndClauseDisjunction Build(IAndClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                return EmptyDisjunction.Instance;
            }

            if (clauses.Length == 1)
            {
                return clauses[0];
            }

            return new AndClauseDisjunction(clauses);
        }
    }
}
