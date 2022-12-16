using Core.Formulas.Disjunctions;

namespace Core.Formulas.Conjunctions
{
    public class ClauseConjunction : And, IClauseConjunction
    {
        public new readonly IClause A;
        public new readonly IClauseConjunction B;


        public ClauseConjunction(IClause[] clauses) : base(default(IFormula), default)
        {
            if (clauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(ClauseConjunction)} instance with one literals");
            }

            A = clauses[0];
            B = IClauseConjunction.Build(clauses[1..]);

            base.A = A;
            base.B = B;
        }
        public IClause[] GetClauses() => B.GetClauses().Concat(A.GetClauses()).ToArray();
    }
}
