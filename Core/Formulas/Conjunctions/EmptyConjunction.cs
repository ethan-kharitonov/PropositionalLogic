using Core.Formulas.Conjunctions.IClauseConjunctions;
using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions;
using Core.TruthAssignments;

namespace Core.Formulas.Conjunctions
{
    public class EmptyConjunction : IAndClause, IClauseConjunction
    {
        public static readonly EmptyConjunction Instance = new();

        private EmptyConjunction() { }
        public bool Evaluate(ITruthAssignment T) => true;


        public IEnumerable<string> GetSymbols() => Enumerable.Empty<string>();
    }
}
