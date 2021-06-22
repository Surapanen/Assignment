using System;
using System.Collections.Generic;
using System.IO;

namespace RetailerMerchant
{
    class CustomerList
    {
        public static List<Customer> custList { get; set; }
        public void LoadFileData(string FileName)
        {
            CalculateRewards calc = new CalculateRewards();

            try
            {
                string[] lines = System.IO.File.ReadAllLines("App_Data/" + FileName);

                foreach (string line in lines)
                {
                    // each line is of format: Cutomer Name, Transaction Amount, Date in YYYY-MM-DD
                    string[] words = line.Split(",");
                    string custName = words[0];
                    double transAmount = double.Parse(words[1]);
                    int reward = calc.GetRewardPoints(transAmount);
                    int month = int.Parse(words[2].Split("-")[1]) - 1;

                    if (custList.Exists(x => x.Name == custName))
                    {
                        custList.Find(x => x.Name == custName).addReward(month, reward);
                    }
                    else
                    {
                        Customer c = new Customer(custName);
                        c.addReward(month, reward);
                        custList.Add(c);
                    }
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
            }
        }
        public void DisplayCustomerList(string FileName)
        {
            int curMonth = DateTime.Today.Month - 1;
            int thisMonth = curMonth;
            int totalPoints;
            Console.WriteLine("Customer Name" + "\t" + "Month3 Reward Points" + "\t" + "Month2 Reward Points" + "\t" + "Month1 Reward Points" + "\t" + "Total three Month Reward Points");
            foreach (Customer c in custList)
            {
                totalPoints = 0;
                Console.Write(c.Name + "\t\t");
                for (int i = 3; i > 0; i--)
                {
                    Console.Write(c.rewards[curMonth] + "\t\t\t");
                    totalPoints = totalPoints + c.rewards[curMonth];
                    curMonth--;
                }
                curMonth = thisMonth;
                Console.Write(totalPoints);
                Console.WriteLine();
            }
        }
        public void AddCustomer(string FileName)
        {
            Console.WriteLine("Enter the customer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Amount spent");
            string amount = Console.ReadLine();
            Console.WriteLine("Enter the date in YYYY-mm-DD");//not checking formats now
            string date = Console.ReadLine();

            double transAmount = double.Parse(amount);
            CalculateRewards calc = new CalculateRewards();
            int reward = calc.GetRewardPoints(transAmount);
            int month = int.Parse(date.Split("-")[1]) - 1;

            if (custList.Exists(x => x.Name == name))
            {
                custList.Find(x => x.Name == name).addReward(month, reward);
            }
            else
            {
                Customer c = new Customer(name);
                c.addReward(month, reward);
                custList.Add(c);
            }
            try
            {
                using (StreamWriter sw = File.AppendText("App_Data/" + FileName))
                {
                    sw.WriteLine(name + "," + amount + "," + date);
                    Console.WriteLine("Customer transaction saved");
                }
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }
        public void DeleteCustomer(string name)
        {
            int removedTrans = 0;
            if (custList.Exists(x => x.Name == name))
            {
                Customer c = custList.Find(x => x.Name == name);
                custList.Remove(c);
                removedTrans++;
            }
            if (removedTrans > 0)
            {
                Console.WriteLine(name + " is deleted from the dataset");
            }
        }
        public void SearchCustomer(string name)
        {
            int found = 0, totRewards = 0;

            if (custList.Exists(x => x.Name == name))
            {
                found++;
                Customer c = custList.Find(x => x.Name == name);
                for (int i = 0; i < 12; i++)
                {
                    totRewards += c.rewards[i];
                }

            }


            if (found > 0)
            {
                Console.WriteLine("Customer found!");
                Console.WriteLine("Customer Name: " + name);
                Console.WriteLine("Total rewards: " + totRewards);

            }
            else
            {
                Console.WriteLine(name + " is not found in the dataset");
            }
        }
    }
}
