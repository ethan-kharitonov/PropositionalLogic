using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;

namespace Core.Formulas.Basic
{
    public interface ILiteral : IClause, IAndClause
    {
        abstract bool IsPositive { get; }
        abstract string Symbol { get; }
    }
}
