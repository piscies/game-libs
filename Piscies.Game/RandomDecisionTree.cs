using System;
using System.Collections.Generic;
using System.Text;

namespace Piscies.Game
{
    public class RandomDecisionTree
    {
        private List<object> decisions;

        public RandomDecisionTree()
        {
            decisions = new List<object>();
        }

        public void AddDecision(object newDecision)
        {
            this.decisions.Add(newDecision);
        }

        public T Decide<T>()
        {
            if (decisions == null || decisions.Count == 0)
                throw new Exception("Random Decision Tree was null or empty and cannot decide");

            object decision;

            if (decisions.Count == 1)
                decision = decisions[0];
            else
                decision = decisions[Die.RandomNumber(0, decisions.Count - 1)];

            return (T)decision;
        }
    }
}
