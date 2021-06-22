using System;
using System.Collections.Generic;

namespace RetailerMerchant
{
    class RewardsProgram
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            String FileName = "SampleDataset.txt";//sample dataset name
            string name ;
            Display disp = new Display();
            CalculateRewards calc = new CalculateRewards();
            CustomerList c = new CustomerList();
            CustomerList.custList = new List<Customer>();
            c.LoadFileData(FileName);
            do
            {
                userInput = disp.DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        RewardsProgram prog = new RewardsProgram();
                        Console.WriteLine("Enter the transaction amount");
                        double transAmt = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Reward points earned: " + calc.GetRewardPoints(transAmt));
                        break;
                    case 2: c.AddCustomer(FileName);
                        break;
                    case 3: c.DisplayCustomerList(FileName);
                        break;
                    case 4: Console.WriteLine("Enter the customer name");
                        name = Console.ReadLine();
                        c.SearchCustomer(name);
                        break;
                    case 5:
                        Console.WriteLine("Enter the customer name");
                        name = Console.ReadLine();
                        c.DeleteCustomer(name);
                        break;
                    case 6:break;

                }
            } while (userInput != 6);
            
            
            }

        
        
    }
}
