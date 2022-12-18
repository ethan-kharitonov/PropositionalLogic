using Core.Formulas.Disjunctions.IAndClauseDisjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public interface IAndClause : INonEmptyAndClauseDisjunction
    {
        public static IAndClause Build(params IAndClause[] andClauses)
        {
            if (andClauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(IAndClause)} from an empty array");
            }

            if (andClauses.Length == 1)
            {
                return andClauses[0];
            }

            return new AndClause(andClauses);
        }
    }
}
