using Core.Formulas.Basic;
using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using Core.TruthAssignments;

namespace Core.ExtensionMethods
{
    public static class FormulaExtensions
    {

        public static bool SyntacticEquals(this IFormula A, IFormula B)
        {
            if (A is ILiteral litA && B is ILiteral litB)
            {
                return litA.IsPositive == litB.IsPositive && litA.Symbol == litB.Symbol;
            }

            if (A is Not notA && B is Not notB)
            {
                return notA.A.SyntacticEquals(notB.A);
            }

            if (A is And andA && B is And andB)
            {
                return andA.A.SyntacticEquals(andB.A) && andA.B.SyntacticEquals(andB.B);
            }

            if (A is Or orA && B is Or orB)
            {
                return orA.A.SyntacticEquals(orB.A) && orA.B.SyntacticEquals(orB.B);
            }

            return false;
        }

        public static IAndClauseDisjunction GetEquivilantDNF(this IFormula f)
        {
            var truthAssignments = GetAllPossibleTruthAssignments(f);
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
                andClauses.Add(IAndClause.BuildClause(literals.ToArray()));
            }

            return IAndClauseDisjunction.Build(andClauses.ToArray());
        }
        /* public static IClauseConjunction GetEquivilandCNF(this IFormula f)
         {
             if(f is ILiteral lit)
             {
                 return lit;
             }

             if(f is And)
             {
                 return 
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
