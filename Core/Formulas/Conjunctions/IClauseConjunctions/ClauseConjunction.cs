using Core.Formulas.Basic;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public class ClauseConjunction : And, INonEmptyClauseConjunction
    {
        public new readonly INonEmptyClauseConjunction A;
        public new readonly INonEmptyClauseConjunction B;


        public ClauseConjunction(INonEmptyClauseConjunction[] nonEmptyClausesConjunctions) : base(default(IFormula), default)
        {
            if (nonEmptyClausesConjunctions.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(ClauseConjunction)} instance with one literals");
            }

            A = (INonEmptyClauseConjunction)IClauseConjunction.Build(nonEmptyClausesConjunctions[..^1]);
            B = nonEmptyClausesConjunctions[^1];

            base.A = A;
            base.B = B;
        }
    }
}
