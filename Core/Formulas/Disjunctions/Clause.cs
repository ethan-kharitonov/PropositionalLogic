namespace Core.Formulas.Disjunctions
{
    //Disjunction of two ro more literls (or the empty clause)
    public class Clause : Or, IClause
    {
        public new IClause A;
        public new ILiteral B;

        //Literals must contain at least two items
        public Clause(ILiteral[] literals) : base(default(IFormula), default)
        {
            if (literals.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(Clause)} instance with one literals");
            }

            A = IClause.BuildClause(literals[..^1]);
            B = literals[^1];

            base.B = B;
            base.A = A;
        }

        public IClause[] GetClauses() => new[] { this };

    }
}
