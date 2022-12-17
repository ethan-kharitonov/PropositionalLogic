namespace Core.Formulas.Disjunctions.IAndClauseDisjunctions
{
    public interface INonEmptyAndClauseDisjunction : IAndClauseDisjunction
    {
        public static new IAndClauseDisjunction Build(params INonEmptyAndClauseDisjunction[] nonEmptyAndClauseDisjunctions)
        {
            if (nonEmptyAndClauseDisjunctions.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(IAndClauseDisjunction)} from empty array");
            }
            return (INonEmptyAndClauseDisjunction)IAndClauseDisjunction.Build(nonEmptyAndClauseDisjunctions);
        }
    }
}
