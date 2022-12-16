using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Formulas;
using Core.Formulas.Basic;

namespace Core.TruthAssignments
{
    public class AllTrueTruthAssignment : ITruthAssignment
    {
        public bool Evaluate(Atom atom)
        {
            return true;
        }
    }
}
