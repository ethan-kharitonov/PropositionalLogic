using Core.ExtensionMethods;
using Core.Formulas.Basic;

namespace Testing
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var P = new Atom("P1");
            var Q = new Atom("P2");
            var S = new Atom("P3");

            var f = P.Or(Q.And(S));
            var DNF = f.GetEquivilandCNF();

            Console.WriteLine($"f:   {f.ToLatex()}");
            Console.WriteLine($"DNF: {DNF.ToLatex()}");
        }
    }
}