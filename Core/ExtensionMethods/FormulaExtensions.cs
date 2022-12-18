using Core.Formulas.Basic;
using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using Core.TruthAssignments;

namespace Core.ExtensionMethods
{
    public static class FormulaExtensions
    {

        public static IAndClauseDisjunction GetEquivilantDNF(this IFormula f)
        {
            var truthAssignments = GetAllPossibleTruthAssignments(f);
            if (!truthAssignments.Any())
            {
                return EmptyDisjunction.Instance;
            }

            var allSymbols = f.GetSymbols();

            var andClauses = new List<IAndClause>();
            foreach (var t in truthAssignments)
            {
                if (!f.Evaluate(t))
                {
                    continue;
                }

                var literals = new List<ILiteral>();
                foreach (var symbol in allSymbols)
                {
                    if (t.trueSymbols.Contains(symbol))
                    {
                        literals.Add(new Atom(symbol));
                    }
                    else
                    {
                        literals.Add(new NotAtom(symbol));
                    }
                }
                andClauses.Add(IAndClause.Build(literals.ToArray()));
            }

            return IAndClauseDisjunction.Build(andClauses.ToArray());
        }

       /* public static IClauseConjunction GetEquivilandCNF(this IFormula f)
        {
            if (f is ILiteral lit)
            {
                return lit;
            }

            if (f is And and)
            {
                var A = GetEquivilandCNF(and.A);
                var B = GetEquivilandCNF(and.B);

                return IClauseConjunction.Build()
            }
        }*/

        public static IEnumerable<FiniteAtomTruthAssignment> GetAllPossibleTruthAssignments(IFormula f)
        {
            var symbols = f.GetSymbols().ToArray();

            foreach (var set in symbols.GetAllSubcollections())
            {
                yield return new FiniteAtomTruthAssignment(set.ToArray());
            }
        }

    }
}
