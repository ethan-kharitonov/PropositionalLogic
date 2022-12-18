
using Core.Formulas.Basic;

namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public interface IClauseConjunction : IFormulaOrEmpty
    {
        public static IClauseConjunction Build(params INonEmptyClauseConjunction[] nonEmptyClausesConjunctions)
        {
            if (nonEmptyClausesConjunctions.Length == 0)
            {
                return EmptyConjunction.Instance;
            }

            if (nonEmptyClausesConjunctions.Length == 1)
            {
                return nonEmptyClausesConjunctions[0];
            }

            return new NonEmptyClauseConjunction(nonEmptyClausesConjunctions);
        }

    }
}
