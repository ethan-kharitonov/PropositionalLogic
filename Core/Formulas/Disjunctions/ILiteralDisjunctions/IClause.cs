using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.IClauseConjunctions;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    //Disjunction of literls
    public interface IClause : INonEmptyClauseConjunction
    {
        public static IClause Build(params IClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create an instance of type {nameof(IClause)} from an empty array");
            }

            if (clauses.Length == 1)
            {
                return clauses[0];
            }

            return new Clause(clauses);
        }
    }

    
}
