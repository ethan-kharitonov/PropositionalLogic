using Core.Formulas.Basic;

namespace Core.Formulas.Disjunctions.ILiteralDisjunctions
{
    //Disjunction of two ro more literls (or the empty clause)
    public class Clause : Or, INonEmptyClause
    {
        public new INonEmptyClause A;
        public new INonEmptyClause B;

        //Literals must contain at least two items
        public Clause(INonEmptyClause[] nonEmptyClauses) : base(default(IFormula), default)
        {
            if (nonEmptyClauses.Length < 2)
            {
                throw new ArgumentException($"Cannot create {nameof(Clause)} instance with one literals");
            }

            A = (INonEmptyClause)IClause.Build(nonEmptyClauses[..^1]);
            B = nonEmptyClauses[^1];

            base.B = B;
            base.A = A;
        }

    }
}
