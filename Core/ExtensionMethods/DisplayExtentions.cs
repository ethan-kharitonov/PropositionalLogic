using Core.Formulas.Basic;
using Core.Formulas.Conjunctions;
using Core.Formulas.Disjunctions;

namespace Core.ExtensionMethods
{
    public static class DisplayExtentions
    {
        public const string LatexNot = @"\neg";
        public const string LatexAnd = @"\land";
        public const string LatexOr = @"\lor";

        public static string ToLatex(this IFormula f) => f switch
        {
            Not n => $"{LatexNot} {n.A.ToLatex()}",
            And and => $"({and.A.ToLatex()} {LatexAnd} {and.B.ToLatex()})",
            Or or => $"({or.A.ToLatex()} {LatexOr} {or.B.ToLatex()})",
            Atom a => a.Symbol,
            EmptyConjunction => @"\land \emptyset",
            EmptyDisjunction => @"\lor \emptyset",
            _ => throw new NotImplementedException(),
        };
    }
}
