using Core.Formulas.Basic;

namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public interface INonEmptyAndClauseDisjunction : IAndClauseDisjunction, IFormula
    {
        public static new INonEmptyAndClauseDisjunction Build(params INonEmptyAndClauseDisjunction[] nonEmptyAndClauseDisjunctions)
        {
            if (nonEmptyAndClauseDisjunctions.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(IAndClauseDisjunction)} from empty array");
            }
            return (INonEmptyAndClauseDisjunction)IAndClauseDisjunction.Build(nonEmptyAndClauseDisjunctions);
        }
    }
}
