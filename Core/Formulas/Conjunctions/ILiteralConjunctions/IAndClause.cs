using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public interface IAndClause : IAndClauseDisjunction
    {
        public static IAndClause Build(params INonEmptyAndClause[] andClauses)
        {
            if (andClauses.Length == 0)
            {
                return EmptyConjunction.Instance;
            }

            if (andClauses.Length == 1)
            {
                return andClauses[0];
            }

            return new AndClause(andClauses);
        }
    }
}
