using Core.Formulas;
using Core.Formulas.Basic;

namespace Core.ExtensionMethods
{
    public static class FluentExtensionsForFormulas
    {
        public static Not Not(this IFormula f) => new(f);
        public static NotAtom Not(this Atom atom) => new(atom.Symbol);
        public static And And(this IFormula A, IFormula B) => new(A, B);
        public static And And(this IFormula A, string B) => new(A, new Atom(B));
        public static Or Or(this IFormula A, IFormula B) => new(A, B);
        public static Or Or(this IFormula A, string B) => new(A, new Atom(B));
    }
}
