using System;

namespace RetailerMerchant
{
    public class Display
    {
        public int DisplayMenu()
        {
            Console.WriteLine("Welcome to the Rewards Program");
            Console.WriteLine("1. Calculate reward");
            Console.WriteLine("2. Add a Customer");
            Console.WriteLine("3. List the customers and Reward for last three months");
            Console.WriteLine("4. Search for a customer");
            Console.WriteLine("5. Delete a customer");
            Console.WriteLine("6. Exit");
            var result = Console.ReadLine();
            int.TryParse(result, out int item);
            return item;
        }
        
    }
}
