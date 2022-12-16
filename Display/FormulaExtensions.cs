using Core;
using System;

namespace Display
{
    public static class FormulaExtensions
    {
        public static string GetLatex(this Formula formula)
        {
            return formula switch
            {
                Atom a => a.Symbol,
                Not f => $"\\neg {f.A.GetLatex()}",
                And f => $"{f.A.GetLatex()} \\land {f.B.GetLatex()}",
                Or f => $"{f.A.GetLatex()} \\lor {f.B.GetLatex()}",
                _ => throw new NotImplementedException($"Cannot draw formula of type {typeof(Formula)}"),
            };
        }
    }
}
