using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.ILiteralConjunctions;

namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public class AndClauseDisjunction : Or, INonEmptyAndClauseDisjunction
    {
        public new readonly INonEmptyAndClauseDisjunction A;
        public new readonly INonEmptyAndClauseDisjunction B;
        public AndClauseDisjunction(params INonEmptyAndClauseDisjunction[] nonEmptyAndClauseDisjunctions) : base(default(IFormula), default)
        {
            if (nonEmptyAndClauseDisjunctions.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClauseDisjunction)} instance with one literals");
            }

            A = INonEmptyAndClauseDisjunction.Build(nonEmptyAndClauseDisjunctions[..^1]);
            B = nonEmptyAndClauseDisjunctions[^1];

            base.A = A;
            base.B = B;
        }
    }
}
