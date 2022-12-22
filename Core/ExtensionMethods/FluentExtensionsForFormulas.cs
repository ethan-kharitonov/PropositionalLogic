using Core.Formulas.Basic;

namespace Core.ExtensionMethods
{
    public static class FluentExtensionsForFormulas
    {
        public static Not Not(this INonEmptyFormula f) => new(f);
        public static ILiteral Not(this ILiteral lit) => lit switch
        {
            Atom => new NotAtom(lit.Symbol),
            NotAtom => new Atom(lit.Symbol),
            _ => throw new NotImplementedException("Cannot take negation of input"),
        };
        public static NotAtom Not(this Atom atom) => new(atom.Symbol);
        public static And And(this INonEmptyFormula A, INonEmptyFormula B) => new(A, B);
        public static And And(this INonEmptyFormula A, string B) => new(A, new Atom(B));
        public static Or Or(this INonEmptyFormula A, INonEmptyFormula B) => new(A, B);
        public static Or Or(this INonEmptyFormula A, string B) => new(A, new Atom(B));
    }
}
