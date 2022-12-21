using Core.Formulas.Basic;
using Core.Formulas.Conjunctions.IClauseConjunctions;
using Core.Formulas.Conjunctions.ILiteralConjunctions;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.IAndClauseDisjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;
using Core.TruthAssignments;
using System.Net.Http.Headers;

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

        public static IClauseConjunction GetEquivilandCNF(this IFormula f)
        {
            switch (f)
            {
                case ILiteral lit:
                    return lit;
                case And and:
                    var A = (INonEmptyClauseConjunction)GetEquivilandCNF(and.A);
                    var B = (INonEmptyClauseConjunction)GetEquivilandCNF(and.B);
                    return INonEmptyClauseConjunction.Build(A, B);
                case Or or:
                    return GetCNFForOr(or);
                case Not not:
                    return GetCNFForNot(not);
                default:
                    throw new NotImplementedException($"Cannot find CNF equivilant for instances of this type");
            }
        }

        private static IClauseConjunction GetCNFForOr(Or or)
        {
            var d = or.Distribute();
            if (d == or)
            {
                if(or.A is ILiteral litA && or.B is ILiteral litB)
                {
                    return new Clause(litA, litB);
                }

                if(or.A is ILiteral litA1)
                {
                    var B = (Or)or.B;
                    return new Clause(litA1, (Clause)GetCNFForOr(B));
                }

                var A = (Or)or.A;
                var B1 = (ILiteral)or.B;
                return new Clause((Clause)GetCNFForOr(A), B1);
            }
            return GetEquivilandCNF(d);
        }

        private static IClauseConjunction GetCNFForNot(Not not) => not.A switch
        {
            Atom => (IClause)not,
            Not => not.RemoveDoubleNegationIfExists().GetEquivilandCNF(),
            And => not.PushNegationInsideIfPossile().GetEquivilandCNF(),
            Or => not.PushNegationInsideIfPossile().GetEquivilandCNF(),
            _ => throw new NotImplementedException(),
        };

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
