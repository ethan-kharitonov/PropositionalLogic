using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public interface IClauseConjunction :  IFormula
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

            return new ClauseConjunction(nonEmptyClausesConjunctions);
        }

    }
}
