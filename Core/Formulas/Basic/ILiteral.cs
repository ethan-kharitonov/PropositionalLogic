using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace Core.Formulas.Basic
{
    public interface ILiteral : INonEmptyClause, INonEmptyAndClause
    {
        abstract bool IsPositive { get; }
        abstract string Symbol { get; }

        public bool IsNegationOf(ILiteral literal)
        {
            return IsPositive != literal.IsPositive && Symbol == literal.Symbol;
        }
    }
}
