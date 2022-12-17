using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    //Conjunction of two or more literals
    public class AndClause : And, INonEmptyAndClause
    {
        public new INonEmptyAndClause A;
        public new INonEmptyAndClause B;

        //Litterals must contain at least two items
        public AndClause(params INonEmptyAndClause[] nonEmptyAndClauses) : base(default(IFormula), default)
        {
            if (nonEmptyAndClauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClause)} instance with one literals");
            }

            A = INonEmptyAndClause.Build(nonEmptyAndClauses[..^1]);
            B = nonEmptyAndClauses[^1];

            base.B = B;
            base.A = A;
        }
    }
}
