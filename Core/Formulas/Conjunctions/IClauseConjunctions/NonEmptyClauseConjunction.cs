using Core.Formulas.Basic;
namespace Core.Formulas.Conjunctions.IClauseConjunctions
{
    public class NonEmptyClauseConjunction : And<INonEmptyClauseConjunction>, INonEmptyClauseConjunction
    {
        public NonEmptyClauseConjunction(INonEmptyClauseConjunction[] nonEmptyClausesConjunctions) : base(default, default)
        {
            if (nonEmptyClausesConjunctions.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(NonEmptyClauseConjunction)} instance with one literals");
            }

            A = INonEmptyClauseConjunction.Build(nonEmptyClausesConjunctions[..^1]);
            B = nonEmptyClausesConjunctions[^1];
        }
    }
}
