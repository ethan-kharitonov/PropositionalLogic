using Core.Formulas.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ExtensionMethods
{
    public static class IFormulaExtensions
    {
        public static bool SyntacticEquals(this IFormula A, IFormula B)
        {
            if (A == B)
            {
                return true;
            }

            if (A is ILiteral litA && B is ILiteral litB)
            {
                return litA.IsPositive == litB.IsPositive && litA.Symbol == litB.Symbol;
            }

            if (A is Not notA && B is Not notB)
            {
                return notA.A.SyntacticEquals(notB.A);
            }

            if (A is And andA && B is And andB)
            {
                return andA.A.SyntacticEquals(andB.A) && andA.B.SyntacticEquals(andB.B);
            }

            if (A is Or orA && B is Or orB)
            {
                return orA.A.SyntacticEquals(orB.A) && orA.B.SyntacticEquals(orB.B);
            }

            return false;
        }
    }
}
