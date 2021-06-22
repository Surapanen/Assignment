using System;

namespace RetailerMerchant
{
    class Customer
    {
        public string Name { get; set; }
        public int[] rewards { get; set; }

        public Customer(String name)
        {
            this.Name = name;
            this.rewards = new int[12]; // for every month in year
        }

        public void addReward(int month, int reward)
        {
            rewards[month] = reward;
        }
    }
}
