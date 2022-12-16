using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Formulas;

namespace Core.TruthAssignments
{
    public interface ITruthAssignment
    {
        public bool Evaluate(Atom atom);
    }
}
