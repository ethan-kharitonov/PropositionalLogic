using Core.Formulas.Disjunctions;
using Core.TruthAssignments;
using System.ComponentModel;

namespace Core.Formulas.Basic
{
    public class Atom : ILiteral
    {
        public bool IsPositive => true;

        string ILiteral.Symbol => Symbol;

        public readonly string Symbol;

        public Atom(string symbol)
        {
            if (!IsValidVariableSymbol(symbol))
            {
                throw new InvalidEnumArgumentException("The symbol must be in the form Px where x is an ineger");
            }

            Symbol = symbol;
        }


        private static bool IsValidVariableSymbol(string symbol)
        {
            if (string.IsNullOrEmpty(symbol))
            {
                return false;
            }

            if (symbol.First() != 'P')
            {
                return false;
            }

            return int.TryParse(symbol[1..], out _);
        }

        public bool Evaluate(ITruthAssignment T) => T.Evaluate(this);

        public IEnumerable<string> GetSymbols()
        {
            yield return Symbol;
        }

    }
}
