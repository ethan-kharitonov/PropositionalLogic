using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.IClauseConjunctions;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    public interface INonEmptyClause : IClause, INonEmptyClauseConjunction
    {
        public new static INonEmptyClause Build(params INonEmptyClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create an instance of type {nameof(IClause)} from an empty array");
            }

            return (INonEmptyClause)IClause.Build(clauses);
        }
    }
}
