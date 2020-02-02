using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piscies.Game
{
    public class PercentageDecisionTree
    {
        private List<PercentageDecision> decisions;

        public PercentageDecisionTree()
        {
            decisions = new List<PercentageDecision>();
        }

        public void AddDecision(object decision, double chance)
        {
            if((decisions.Sum(x => x.Percentage) + chance) > 100.0)
            {
                throw new Exception("New decision in PercentageDecisionTree would surpass 100% limit");
            }

            decisions.Add(new PercentageDecision(decision, chance));
        }

        internal void AddDecisions(List<PercentageDecision> newDecisions)
        {
            foreach (PercentageDecision decision in newDecisions)
                AddDecision(decision.DecisionObject, decision.Percentage);
        }

        public T Decide<T>(double percentageValue)
        {
            if(decisions.Sum(x => x.Percentage) != 100.0)
            {
                throw new Exception("Percentage DecisionTree tried to resolve with chances higher or lower than 100%");
            }

            double currentPercentage = 0.0;
            
            foreach(PercentageDecision decision in decisions)
            {
                if (percentageValue <= (decision.Percentage + currentPercentage))
                {
                    return (T)decision.DecisionObject;
                }
                else
                    currentPercentage += decision.Percentage;
            }

            return default(T);
        }
    }
}
