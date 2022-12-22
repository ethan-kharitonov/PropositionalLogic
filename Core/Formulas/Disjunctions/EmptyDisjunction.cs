using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;
using Core.TruthAssignments;

namespace Core.Formulas.Disjunctions
{
    public class EmptyDisjunction : IClause, IAndClauseDisjunction
    {
        public static readonly EmptyDisjunction Instance = new();
        private EmptyDisjunction() { }

        public bool Evaluate(ITruthAssignment _) => false;

        public IEnumerable<string> GetSymbols() => Enumerable.Empty<string>();
    }
}
