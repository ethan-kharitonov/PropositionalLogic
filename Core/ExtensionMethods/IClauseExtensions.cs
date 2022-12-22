using Core.Formulas.Basic;
using Core.Formulas.Disjunctions;
using Core.Formulas.Disjunctions.ILiteralDisjunctions;
using Core.TruthAssignments;
using System.Collections.Generic;

namespace Core.ExtensionMethods
{
    public static class IClauseExtensions
    {
        public static (IEnumerable<IClause>, FiniteAtomTruthAssignment) TryGetResolutionRefutation(this IEnumerable<IClause> S)
        {
            if (S.Contains(EmptyDisjunction.Instance))
            {
                return (new[] { EmptyDisjunction.Instance }, null);
            }
            S = (IEnumerable<INonEmptyClause>)S;

            var STag = S.ToList();
            var literals = new Stack<ILiteral>();
            var t = new FiniteAtomTruthAssignment();

            var result = Step2(S, literals, t);
            if(result != (null, null))
            {
                return result;
            }

             C = S.FindUnsatisfiedClause(t);
            if (C == null)
            {
                return (null, t);
            }

            literals.Pop();
            literals.Push(l.Not());

        }

        private static (IEnumerable<IClause>, FiniteAtomTruthAssignment) Step2(IEnumerable<IClause> S, Stack<ILiteral> literals , FiniteAtomTruthAssignment t)
        {
            var C = S.FindUnsatisfiedClause(t);
            if (C == null)
            {
                return (null, t);
            }

            var l = FindUnsatisfiedLiterl(C.GetLiterals(), t);
            literals.Push(l);
            t = new FiniteAtomTruthAssignment(l.Symbol);

            return (null, null);
        }

        private static 

        private static IClause FindUnsatisfiedClause(this IEnumerable<IClause> S, ITruthAssignment t)
        {
            foreach(var s in S)
            {
                if (!s.Evaluate(t))
                {
                    return s;
                }
            }

            return null;
        }

        private static ILiteral FindUnsatisfiedLiterl(IEnumerable<ILiteral> literals, ITruthAssignment t)
        {
            foreach (var lit in literals)
            {
                if (!lit.Evaluate(t))
                {
                    return lit;
                }
            }

            throw new ArgumentException();
        }

        public static IEnumerable<ILiteral> GetLiterals(this IClause clause)
        {
            if(clause == EmptyDisjunction.Instance)
            {
                yield break;
            }

            if(clause is ILiteral lit)
            {
                yield return lit; 
            }

            var c = (Clause)clause;

            foreach(var x in c.A.GetLiterals())
            {
                yield return x;
            }

            foreach (var x in c.B.GetLiterals())
            {
                yield return x;
            }
        }
    }
}
