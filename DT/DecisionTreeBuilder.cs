using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT
{
    internal class DecisionTreeBuilder
    {
        private DecisionTreeNode _root;

        public DecisionTreeBuilder()
        {

        }
        public void SetRootNode(DecisionTreeNode root)
        {
            _root = root;
        }
        public void AddNode(Decision.Decision decision, DecisionTreeNode trueNode, DecisionTreeNode falseNode) 
        {
            decision.TrueNode = trueNode;
            decision.FalseNode = falseNode;
        }

    }
}
