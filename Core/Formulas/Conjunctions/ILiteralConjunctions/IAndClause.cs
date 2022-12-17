using Core.Formulas.Disjunctions.IAndClauseDisjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    //Conjunction of literals
    public interface IAndClause : IAndClauseDisjunction
    {
        public static IAndClause Build(params INonEmptyAndClause[] nonEmptyAndClauses)
        {
            if (nonEmptyAndClauses.Length == 0)
            {
                return EmptyConjunction.Instance;
            }

            if (nonEmptyAndClauses.Length == 1)
            {
                return nonEmptyAndClauses[0];
            }

            return new AndClause(nonEmptyAndClauses);
        }
    }
}
