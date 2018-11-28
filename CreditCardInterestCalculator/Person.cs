using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    class Person
    {
        public string FullName { get; set; }
        public int nWallets { get; set; }
        public Wallet[] Wallets { get; set; }
        public decimal TotalInterest { get; set; } = 0;

        public void InterestCalculation()
        {
            this.Wallets = new Wallet[nWallets];
            //loop throu each wallet
            for (int i = 0; i < this.nWallets; i++)
            {
                this.Wallets[i] = new Wallet();
                GetNumberOfCards(i);
                this.Wallets[i].Cards = new CreditCard[this.Wallets[i].NCards];
                //loop throu each card
                for (int j = 0; j < this.Wallets[i].NCards; j++)
                {
                    SetCardTypeAndInterest(i, j);
                    SetCardBalance(i, j);
                    this.Wallets[i].Cards[j].CInterest = this.Wallets[i].Cards[j].Balance * (this.Wallets[i].Cards[j].Interest/100);
                    this.Wallets[i].WInterest += this.Wallets[i].Cards[j].CInterest;
                }
                this.TotalInterest += this.Wallets[i].WInterest;
            }
            CalcInterest();
        }
        private void GetNumberOfCards(int i)
        {
            Console.WriteLine("Enter Wallet(" + (i + 1) + ") number of cards:");
            int intTemp = 0;
            try
            {
                intTemp = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                do
                {
                    Console.WriteLine("Please Re-enter Wallet(" + (i + 1) + ") number of cards:");
                } while (!Int32.TryParse(Console.ReadLine(), out intTemp));
            }
            this.Wallets[i].NCards = intTemp;
            Console.WriteLine(" ");
        }
        private void SetCardTypeAndInterest(int i,int j)
        {
            Console.WriteLine("Select Card(" + (j + 1) + ") type (1- Visa, 2- MC, 3- Discover):");
            int intTemp = 0;
            try
            {
                intTemp = Convert.ToInt32(Console.ReadLine());
                if (intTemp < 1 || intTemp > 3) throw new Exception();
            }
            catch
            {
                do
                {
                    Console.WriteLine("Please Re-select Card(" + (j + 1) + ") type (1- Visa, 2- MC, 3- Discover):");
                } while (!Int32.TryParse(Console.ReadLine(), out intTemp) || (intTemp < 1 || intTemp > 3));
            }
            this.Wallets[i].Cards[j] = new CreditCard();
            this.Wallets[i].Cards[j].Type = (CreditCard.CreditCardType)intTemp;
            switch (this.Wallets[i].Cards[j].Type)
            {
                case CreditCard.CreditCardType.Visa:
                    this.Wallets[i].Cards[j].Interest = 10;
                    break;
                case CreditCard.CreditCardType.MC:
                    this.Wallets[i].Cards[j].Interest = 5;
                    break;
                case CreditCard.CreditCardType.Discover:
                    this.Wallets[i].Cards[j].Interest = 1;
                    break;
            }
            Console.WriteLine(" ");
        }
        private void SetCardBalance(int i, int j)
        {
            Console.WriteLine("Enter " + this.Wallets[i].Cards[j].Type.ToString() + " card balance:");
            decimal intTemp = 0;
            try
            {
                intTemp = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                do
                {
                    Console.WriteLine("Please Re-enter " + this.Wallets[i].Cards[j].Type.ToString() + " card balance:");
                } while (!Decimal.TryParse(Console.ReadLine(), out intTemp));
            }
            this.Wallets[i].Cards[j].Balance = intTemp;
            Console.WriteLine(" ");
        }
        private void CalcInterest()
        {
            Console.WriteLine(FullName.ToUpper() + " Total Interest is: " + TotalInterest.ToString("C2"));
            Console.WriteLine("     Breaking down each wallet interest:");
            for (int i = 0; i < this.nWallets; i++)
            {
                Console.WriteLine("     Wallet(" + (i + 1) + ") Interest is: " + this.Wallets[i].WInterest.ToString("C2"));
                Console.WriteLine("         Breaking down each wallet's card interest:");
                for (int j = 0; j < this.Wallets[i].NCards; j++)
                {
                    Console.WriteLine("         Wallet(" + (i + 1) + "): Card(" + this.Wallets[i].Cards[j].Type.ToString() + ") Interest is: " + this.Wallets[i].Cards[j].CInterest.ToString("C2"));
                }
                Console.WriteLine("     End Wallet(" + (i + 1) + ")------------------------------------------------------------");
                Console.WriteLine(" ");
            }
            Console.WriteLine("End " + FullName + " Interest Summary...................");
            Console.WriteLine(" ");
        }
    }
    class Wallet
    {
        public CreditCard[] Cards { get; set; }
        public int NCards { get; set; }
        public decimal WInterest { get; set; } = 0;
    }
    class CreditCard
    {
        public enum CreditCardType
        {
            Visa = 1,
            MC = 2,
            Discover = 3
        }
        public CreditCardType Type { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
        public decimal CInterest { get; set; } = 0;
    }
}
