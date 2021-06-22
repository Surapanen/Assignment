using System;

namespace RetailerMerchant
{
    class CalculateRewards
    {
        public const int RewardAbove50 = 1;
        public const int RewardAbove100 = 2;

        public int GetRewardPoints(double transactionAmt)
        {
            transactionAmt = Math.Floor(transactionAmt); // reward for each "dollar" amount over 50
            double totalRewards = 0;

            if (transactionAmt <= 50)
            {
                totalRewards = 0;

            }
            else if (transactionAmt <= 100)
            {
                totalRewards = (transactionAmt - 50) * RewardAbove50; // for any dollar > 50 and < 100, reward is one point
            }
            else if (transactionAmt > 100)
            {
                totalRewards = (((transactionAmt - 100) * RewardAbove100) + 50); // for any dollar >100, reward is two points
            }

            int reward = Convert.ToInt32(totalRewards);
            return reward;
        }
    }
   
}
