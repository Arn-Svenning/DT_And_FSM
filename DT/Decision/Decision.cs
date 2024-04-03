using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Decision
{
    internal abstract class Decision : DecisionTreeNode
    {
        public DecisionTreeNode TrueNode { get; set; }
        public DecisionTreeNode FalseNode { get; set; }

        protected GameObject _gameObject;
        public Decision(GameObject gameobject)
        {

            _gameObject = gameobject;
        }

        public abstract bool TestValue(GameObject gameObject);

        public virtual DecisionTreeNode GetBranch()
        {
            if (TestValue(_gameObject))
            {
                return TrueNode;
            }
            else
            {
                return FalseNode;
            }
        }
        public override DecisionTreeNode MakeDecision()
        {
            DecisionTreeNode branch = GetBranch();

            return branch.MakeDecision();

        }
    }
}
