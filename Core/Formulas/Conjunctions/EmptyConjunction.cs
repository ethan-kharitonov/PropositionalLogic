using Core.Formulas.Disjunctions;
using Core.TruthAssignments;

namespace Core.Formulas.Conjunctions
{
    public class EmptyConjunction : IAndClause, IClauseConjunction
    {
        public static readonly EmptyConjunction Instance = new();

        private EmptyConjunction() { }
        public bool Evaluate(ITruthAssignment T) => true;

        public IClause[] GetClauses() => Array.Empty<IClause>();

        public IEnumerable<string> GetSymbols() => Enumerable.Empty<string>();
    }
}
