using Core.Formulas.Basic;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;
using Core.Formulas.Disjunctions;

namespace Core.ExtensionMethods
{
    public static class INonEmptyClauseExtensions
    {

        public static IClause GetResolventWith(this INonEmptyClause A, INonEmptyClause B)
        {
            if (A is ILiteral litA && B is ILiteral litB)
            {
                return litA.IsNegationOf(litB) ? EmptyDisjunction.Instance :
                    throw new NotImplementedException($"If both inputs are instances of {nameof(ILiteral)} then one must be the negation of the other.");
            }

            var cA = (Clause)A;
            var cB = (Clause)B;

            var subClausesA = new[] { cA.A, cA.B };
            var subClausesB = new[] { cB.A, cB.B };

            for (int i = 0; i < subClausesA.Length; i++)
            {
                for (int j = 0; j < subClausesB.Length; j++)
                {
                    if (!AreLiteralNegations(subClausesA[i], subClausesB[j]))
                    {
                        continue;
                    }

                    return new Clause(subClausesA[1 - i], subClausesB[1 - j]);
                }
            }

            throw new NotImplementedException("Cannot compute resolvent for the given inputs");
        }

        private static bool AreLiteralNegations(IFormula A, IFormula B)
        {
            return A is ILiteral litA && B is ILiteral litB && litA.IsNegationOf(litB);
        }
    }
}
