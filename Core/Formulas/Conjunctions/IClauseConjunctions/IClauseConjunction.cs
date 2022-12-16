using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public interface IClauseConjunction :  IFormula
    {
        public static IClauseConjunction Build(params IClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                return EmptyConjunction.Instance;
            }

            if (clauses.Length == 1)
            {
                return clauses[0];
            }

            return new ClauseConjunction(clauses);
        }

    }
}
