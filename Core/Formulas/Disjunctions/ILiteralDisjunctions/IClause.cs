using Core.Formulas.Conjunctions.IClauseConjunctions;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    //Disjunction of literls
    public interface IClause : IClauseConjunction
    {
        public static IClause Build(params INonEmptyClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                return EmptyDisjunction.Instance;
            }

            if (clauses.Length == 1)
            {
                return clauses[0];
            }

            return new Clause(clauses);
        }
    }

    
}
