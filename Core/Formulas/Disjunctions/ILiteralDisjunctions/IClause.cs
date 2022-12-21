using Core.Formulas.Basic;
using Core.Formulas.Conjunctions.IClauseConjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using System.Reflection.Metadata.Ecma335;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    //Disjunction of literls
    public interface IClause : INonEmptyClauseConjunction
    {
        public static IClause Build(params IClause[] clauses)
        {
            if (clauses.Length == 0)
            {
                throw new ArgumentException($"Cannot create an instance of type {nameof(IClause)} from an empty array");
            }

            if (clauses.Length == 1)
            {
                return clauses[0];
            }

            return new Clause(clauses);
        }

        public static IAndClauseDisjunction GetResolventWith(this IClause A, IClause B)
        {
            if (A is ILiteral litA && B is ILiteral litB)
            {
                return litA.IsNegationOf(litB) ? EmptyDisjunction.Instance :
                    throw new NotImplementedException($"If both inputs are instances of {nameof(ILiteral)} then one must be the negation of the other.");
            }

            var cA = (Clause)A;
            var cB = (Clause)B;

            var litsA = new[] { cA.A, cA.B };
            var litsB = new[] { cB.A, cB.B };

            for (int i = 0; i < litsA.Length; i++)
            {
                for (int j = 0; j < litsB.Length; j++)
                {
                    if (!AreLiteralNegations(litsA[i], litsB[j]))
                    {
                        continue;
                    }

                    if(litsA[1 - i] is IClause c1 && litsB[1 - j] is IClause c2)
                    {
                        return new Clause(c1, c2);
                    }
                }
            }
        }
        
        private static bool AreLiteralNegations(IFormula A, IFormula B)
        {
            return A is ILiteral litA && B is ILiteral litB && litA.IsNegationOf(litB);
        }
        

        private static bool OrContainsAtLeastOneLiteral(Or or)
        {
            return or.A is ILiteral || or.B is ILiteral;
        }
    }

    
}
