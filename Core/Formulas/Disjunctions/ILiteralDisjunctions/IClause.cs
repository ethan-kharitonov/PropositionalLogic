using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.IClauseConjunctions;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    //Disjunction of literls
    public interface IClause : IClauseConjunction
    {
        public static IClause BuildClause(INonEmptyClause[] nonEmptyClauses)
        {
            if (nonEmptyClauses.Length == 0)
            {
                return EmptyDisjunction.Instance;
            }

            if (nonEmptyClauses.Length == 1)
            {
                return nonEmptyClauses[0];
            }

            return new Clause(nonEmptyClauses);
        }
    }

    
}
