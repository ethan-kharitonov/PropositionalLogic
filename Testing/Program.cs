using Core.ExtensionMethods;
using Core.Formulas.Basic;

internal class Program
{
    private static void Main(string[] args)
    {
        var P = new Atom("P1");
        var Q = new Atom("P2");
        var S = new Atom("P3");

        var f = S.And(Q.Or(S.Not()));
        var DNF = f.GetEquivilantDNF();

        Console.WriteLine($"f:   {f.ToLatex()}");
        Console.WriteLine($"DNF: {DNF.ToLatex()}");
    }
}