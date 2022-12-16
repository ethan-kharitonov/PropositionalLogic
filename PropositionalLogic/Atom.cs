using System.ComponentModel;
namespace PropositionalLogic
{
    public class Atom : Formula
    {
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
    }
}
