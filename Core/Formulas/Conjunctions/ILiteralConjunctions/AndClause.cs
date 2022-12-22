using Core.Formulas.Basic;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public class AndClause : And<INonEmptyAndClause>, INonEmptyAndClause
    {
        public AndClause(params INonEmptyAndClause[] nonEmptyAndClauses) : base(default, default)
        {
            if (nonEmptyAndClauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClause)} instance with one literals");
            }

            A = INonEmptyAndClause.Build(nonEmptyAndClauses[..^1]);
            B = nonEmptyAndClauses[^1];
        }
    }
}
