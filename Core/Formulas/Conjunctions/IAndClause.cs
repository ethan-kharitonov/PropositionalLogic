using Core.Formulas.Disjunctions;

namespace Core.Formulas.Conjunctions
{
    //Conjunction of literals
    public interface IAndClause : IAndClauseDisjunction
    {
        public static IAndClause BuildClause(ILiteral[] literals)
        {
            if (literals.Length == 0)
            {
                return EmptyConjunction.Instance;
            }

            if (literals.Length == 1)
            {
                return literals[0];
            }

            return new AndClause(literals);
        }
    }
}
