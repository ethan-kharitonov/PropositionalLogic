using Core.Formulas.Conjunctions.IClauseConjunctions;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    public interface INonEmptyClause : IClause, INonEmptyClauseConjunction
    {
        public static new INonEmptyClause Build(INonEmptyClause[] nonEmptyClauses)
        {
            if(nonEmptyClauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(INonEmptyClause)} from empty array");
            }
            return (INonEmptyClause)IClause.Build(nonEmptyClauses);
        }
    }
}
