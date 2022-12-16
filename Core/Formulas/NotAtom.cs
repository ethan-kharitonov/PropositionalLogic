using Core.Formulas.Disjunctions;

namespace Core.Formulas
{
    public class NotAtom : Not, ILiteral
    {
        public bool IsPositive => false;

        string ILiteral.Symbol => Symbol;
        public readonly string Symbol;

        public NotAtom(string symbol) : base(new Atom(symbol))
        {
            Symbol = symbol;
        }

        public IClause[] GetClauses() => new[] { this };
    }
}
