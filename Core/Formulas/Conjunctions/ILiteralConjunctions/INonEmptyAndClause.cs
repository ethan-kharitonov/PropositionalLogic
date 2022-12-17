using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Formulas.Conjunctions.ILiteralConjunctions
{
    public interface INonEmptyAndClause : IAndClause, INonEmptyAndClauseDisjunction
    {
    }
}
