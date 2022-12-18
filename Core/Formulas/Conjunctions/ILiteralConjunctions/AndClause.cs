using Core.Formulas.Basic;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public class AndClause : And<IAndClause>, IAndClause
    {
        public AndClause(params IAndClause[] nonEmptyAndClauses) : base(default, default)
        {
            if (nonEmptyAndClauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClause)} instance with one literals");
            }

            A = IAndClause.Build(nonEmptyAndClauses[..^1]);
            B = nonEmptyAndClauses[^1];
        }
    }
}
