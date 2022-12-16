using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.ILiteralConjunctions;

namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public class AndClauseDisjunction : Or, IAndClauseDisjunction
    {
        public new readonly IAndClause A;
        public new readonly IAndClauseDisjunction B;
        public AndClauseDisjunction(IAndClause[] clauses) : base(default(IFormula), default)
        {
            if (clauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClauseDisjunction)} instance with one literals");
            }

            A = clauses[0];
            B = IAndClauseDisjunction.Build(clauses[1..]);

            base.A = A;
            base.B = B;
        }
    }
}
