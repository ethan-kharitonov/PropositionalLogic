using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Conjunctions.IClauseConjunctions;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using System.Runtime.CompilerServices;

namespace Core.ExtensionMethods
{
    public static class DisplayExtentions
    {
        public const string LatexNot = @"\neg";
        public const string LatexAnd = @"\land";
        public const string LatexOr = @"\lor";
        public const string LatexEmptySet = @"\emptyset";

        public static string ToLatex(this IFormulaOrEmpty f) => f switch
        {
            Not n => $"{LatexNot} {n.A.ToLatex()}",
            And and => $"({and.A.ToLatex()} {LatexAnd} {and.B.ToLatex()})",
            Or or => $"({or.A.ToLatex()} {LatexOr} {or.B.ToLatex()})",
            Atom a => a.Symbol,
            EmptyDisjunction => $"{LatexOr} {LatexEmptySet}",
            EmptyConjunction => $"{LatexAnd} {LatexEmptySet}",
            _ => throw new NotImplementedException(),
        };
    }

}
