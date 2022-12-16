namespace Core.Formulas.Conjunctions
{
    //Conjunction of two or more literals
    public class AndClause : And, IAndClause
    {
        public new ILiteral A;
        public new IAndClause B;

        //Litterals must contain at least two items
        public AndClause(ILiteral[] literals) : base(default(IFormula), default)
        {
            if (literals.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(AndClause)} instance with one literals");
            }

            A = literals[0];
            B = IAndClause.BuildClause(literals[1..]);

            base.A = A;
            base.B = B;
        }
    }
}
