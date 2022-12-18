using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using Core.TruthAssignments;
namespace Core.Formulas.Disjunctions
{
    public class EmptyDisjunction : IAndClauseDisjunction
    {
        public static readonly EmptyDisjunction Instance = new();
        private EmptyDisjunction() { }

        public bool Value = true;
    }
}
