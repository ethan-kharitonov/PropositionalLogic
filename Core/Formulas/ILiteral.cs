using Core.Formulas.Conjunctions;
using Core.Formulas.Disjunctions;

namespace Core.Formulas
{
    public interface ILiteral : IClause, IAndClause
    {
         abstract bool IsPositive {get;}
        abstract string Symbol { get; }
    }
}
