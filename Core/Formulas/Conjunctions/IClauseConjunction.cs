using Core.Formulas.Disjunctions;

namespace Core.Formulas.Conjunctions
{
    public interface IClauseConjunction :  IFormula
    {
        public static IClauseConjunction Build(params IClauseConjunction[] clauseConjunctions)
        {
            if (clauseConjunctions.Length == 0)
            {
                return EmptyConjunction.Instance;
            }


        }

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

        public IClause[] GetClauses();
    }
}
