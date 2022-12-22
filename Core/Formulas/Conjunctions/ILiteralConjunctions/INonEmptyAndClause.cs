using Core.Formulas.Disjunctions.IAndClauseDisjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public interface INonEmptyAndClause : IAndClause, INonEmptyAndClauseDisjunction
    {
        public new static INonEmptyAndClause Build(params INonEmptyAndClause[] andClauses)
        {
            if (andClauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(IAndClause)} from an empty array");
            }

            return (INonEmptyAndClause)IAndClause.Build(andClauses);
        }
    }
}
