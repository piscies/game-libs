using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Piscies.Game
{
    public class NormalDistributionDecisionTree
    {
        private List<PercentageDecision> decisions;
        private PercentageDecisionTree decisionTree;

        public enum NormaDistributionType
        {
            Normal = 1,
            Upper = 2,
            Lower = 3
        }

        private NormalDistributionDecisionTree(NormalDistributionDecisionTree tree1, NormalDistributionDecisionTree tree2)
        {
            decisions = new List<PercentageDecision>();

            foreach(PercentageDecision decision in tree1.decisions)
            {
                decisions.Add(decision);
            }

            foreach (PercentageDecision decision in tree2.decisions)
            {
                PercentageDecision foundDecision = decisions.FirstOrDefault(x => (int)x.DecisionObject == (int)decision.DecisionObject);
                if (foundDecision != null)
                    foundDecision.Percentage += decision.Percentage;
                else
                    decisions.Add(decision);
            }

            decisions.ForEach(x => x.Percentage /= 2);

            //Creates the decision tree
            decisionTree = new PercentageDecisionTree();
            decisionTree.AddDecisions(decisions);
        }

        public NormalDistributionDecisionTree(int minValue, int maxValue)
        {
            if (maxValue - minValue < 5)
                throw new Exception("NormalDistributionDecisionTree should have at least a gap of 6 numbers to start with");

            if (((maxValue - minValue + 1) % 2) == 1)
                throw new Exception("Value gap in NormalDistributionDecisionTree should be even (we don't work with an odd amount of decisions yet)");

            decisions = new List<PercentageDecision>();

            //Creating new decision tree
            int[] decisionArray = new int[maxValue - minValue + 1];

            for (int i = 0, j = minValue; j <= maxValue; i++, j++)
                decisionArray[i] = j;

            double currentChance = 50.0;
            for (int i = 0; i < decisionArray.Length / 2; i++)
            {
                int index1 = 0 + (decisionArray.Length / 2) - i - 1;
                int index2 = decisionArray.Length - (decisionArray.Length / 2) + i;

                currentChance /= 2;

                decisions.Add(new PercentageDecision(decisionArray[index1], currentChance));
                decisions.Add(new PercentageDecision(decisionArray[index2], currentChance));
            }

            //Check whats left and adds to main decisions
            double leftoverValue = 100.0 - decisions.Sum(x => x.Percentage);
            decisions.Where(x => x.Percentage == 25.0).ToList().ForEach(x => x.Percentage += leftoverValue / 2);

            //Creates the decision tree
            decisionTree = new PercentageDecisionTree();
            decisionTree.AddDecisions(decisions);
        }

        public int Decide(double percentageValue)
        {
            return decisionTree.Decide<int>(percentageValue);
        }

        public static NormalDistributionDecisionTree Merge(NormalDistributionDecisionTree tree1, NormalDistributionDecisionTree tree2)
        {
            return new NormalDistributionDecisionTree(tree1, tree2);
        }
    }
}
