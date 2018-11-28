using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            do
            {
                Person p = new Person();
                Console.WriteLine("Enter person name:");
                p.FullName = Console.ReadLine();
                Console.WriteLine("Enter " + p.FullName + " number of wallets:");
                int intTemp = 0;
                try
                {
                    intTemp = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    do
                    {
                        Console.WriteLine("Please Re-enter number of wallets:");
                    } while (!Int32.TryParse(Console.ReadLine(), out intTemp));
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                p.nWallets = intTemp;
                p.InterestCalculation();

                Console.WriteLine(" ");
                Console.WriteLine("Enter 'n' for next person; otherwise exit...");
            }
            while (Console.ReadLine().ToString().ToLower() ==  "n");
        }
       
    }
}
