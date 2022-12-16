using Core.Formulas.Conjunctions;

namespace Core.Formulas.Disjunctions
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
