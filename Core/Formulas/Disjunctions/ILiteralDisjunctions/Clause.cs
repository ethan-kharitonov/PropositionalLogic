using Core.Formulas.Basic;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    public class Clause : Or<IClause>, IClause
    {
        public Clause(params IClause[] nonEmptyClauses) : base(default, default)
        {
            if (nonEmptyClauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(Clause)} instance with one literals");
            }

            A = IClause.Build(nonEmptyClauses[..^1]);
            B = nonEmptyClauses[^1];
        }

    }
}
