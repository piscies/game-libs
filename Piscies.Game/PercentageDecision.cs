using System;
using System.Collections.Generic;
using System.Text;

namespace Piscies.Game
{
    internal class PercentageDecision
    {
        public object DecisionObject { get; set; }
        public double Percentage { get; set; }

        public PercentageDecision(object decisionObject, double percentage)
        {
            this.DecisionObject = decisionObject;
            this.Percentage = percentage;
        }
    }
}
