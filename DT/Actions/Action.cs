using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions
{
    internal abstract class Action : DecisionTreeNode
    {
        private GameObject _gameObject;

        public Action(GameObject gameObject)
        {
            this._gameObject = gameObject;
        }

        public override DecisionTreeNode MakeDecision()
        {
            PerformAction(_gameObject);

            return this;
        }

        protected abstract void PerformAction(GameObject gameObject);

    }
}
