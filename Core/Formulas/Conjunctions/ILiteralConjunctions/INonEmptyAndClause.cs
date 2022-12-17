using Core.Formulas.Disjunctions.IAndClauseDisjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public interface INonEmptyAndClause : IAndClause, INonEmptyAndClauseDisjunction
    {
        public static new INonEmptyAndClause Build(params INonEmptyAndClause[] nonEmptyAndClauses)
        {
            if (nonEmptyAndClauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(INonEmptyAndClause)} from empty array");
            }
            return (INonEmptyAndClause)IAndClause.Build(nonEmptyAndClauses);
        }
    }
}
