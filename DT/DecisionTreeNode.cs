using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT
{
    internal abstract class DecisionTreeNode
    {
        public DecisionTreeNode()
        {

        }
        public abstract DecisionTreeNode MakeDecision();
    }
}
