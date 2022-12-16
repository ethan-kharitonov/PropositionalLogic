using Core.Formulas.Conjunctions;

namespace Core.Formulas.Disjunctions
{
    //Disjunction of literls
    public interface IClause : IClauseConjunction
    {
        public static IClause BuildClause(ILiteral[] literals)
        {
            if (literals.Length == 0)
            {
                return EmptyDisjunction.Instance;
            }

            if (literals.Length == 1)
            {
                return literals[0];
            }

            return new Clause(literals);
        }
    }

    
}
