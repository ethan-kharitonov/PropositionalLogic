namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public interface INonEmptyClauseConjunction : IClauseConjunction
    {
        public static new INonEmptyClauseConjunction Build(params INonEmptyClauseConjunction[] nonEmptyClausesConjunctions)
        {
            if (nonEmptyClausesConjunctions.Length == 0)
            {
                throw new ArgumentException($"Cannot create instance of {nameof(INonEmptyClauseConjunction)} from empty array");
            }
            return (INonEmptyClauseConjunction)IClauseConjunction.Build(nonEmptyClausesConjunctions);
        }
    }
}
