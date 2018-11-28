using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardInterestCalculator;

namespace CalcTest
{
    
    [TestClass]
    public class CalcTest
    {
        //static void Main(string[] args)
        //{
        //    CalcTest ct = new CalcTest();
        //    ct.Test_Sen1();
        //    ct.Test_Sen2();
        //    ct.Test_Sen3();
        //    Console.ReadLine();
        //}

        [TestMethod]
        public void Test_Sen1()
        {
            Person p = new Person();
            p.FullName = "Person1";
            p.nWallets = 1;
            p.Wallets = new Wallet[p.nWallets];
            p.Wallets[0] = new Wallet();
            p.Wallets[0].NCards = 3;
            p.Wallets[0].Cards = new CreditCard[p.Wallets[0].NCards];
            p.Wallets[0].Cards[0] = new CreditCard();
            p.Wallets[0].Cards[0].Balance = 100;
            p.Wallets[0].Cards[0].Type = CreditCard.CreditCardType.Visa;
            p.Wallets[0].Cards[0].Interest = 10;
            p.Wallets[0].Cards[1] = new CreditCard();
            p.Wallets[0].Cards[1].Balance = 100;
            p.Wallets[0].Cards[1].Type = CreditCard.CreditCardType.MC;
            p.Wallets[0].Cards[1].Interest = 5;
            p.Wallets[0].Cards[2] = new CreditCard();
            p.Wallets[0].Cards[2].Balance = 100;
            p.Wallets[0].Cards[2].Type = CreditCard.CreditCardType.Discover;
            p.Wallets[0].Cards[2].Interest = 1;
            p.InterestCalculation();

            Assert.IsTrue(p.TotalInterest==16 && p.Wallets[0].Cards[0].CInterest==10 && p.Wallets[0].Cards[1].CInterest == 5 && p.Wallets[0].Cards[2].CInterest == 1, "Person1 total interest should be $16.00\nCard1 interest should be $10.00\nCard2 interest should be $5.00\nCard3 interest should be $1.00");
        }

        [TestMethod]
        public  void Test_Sen2()
        {
            Person p = new Person();
            p.FullName = "Person2";
            p.nWallets = 2;
            p.Wallets = new Wallet[p.nWallets];
            p.Wallets[0] = new Wallet();
            p.Wallets[0].NCards = 2;
            p.Wallets[0].Cards = new CreditCard[p.Wallets[0].NCards];
            p.Wallets[0].Cards[0] = new CreditCard();
            p.Wallets[0].Cards[0].Balance = 100;
            p.Wallets[0].Cards[0].Type = CreditCard.CreditCardType.Visa;
            p.Wallets[0].Cards[0].Interest = 10;
            p.Wallets[0].Cards[1] = new CreditCard();
            p.Wallets[0].Cards[1].Balance = 100;
            p.Wallets[0].Cards[1].Type = CreditCard.CreditCardType.Discover;
            p.Wallets[0].Cards[1].Interest = 1;

            p.Wallets[1] = new Wallet();
            p.Wallets[1].NCards = 1;
            p.Wallets[1].Cards = new CreditCard[p.Wallets[0].NCards];
            p.Wallets[1].Cards[0] = new CreditCard();
            p.Wallets[1].Cards[0].Balance = 100;
            p.Wallets[1].Cards[0].Type = CreditCard.CreditCardType.MC;
            p.Wallets[1].Cards[0].Interest = 5;

            p.InterestCalculation();

            Assert.IsTrue(p.TotalInterest == 16 && p.Wallets[0].WInterest == 11 && p.Wallets[1].WInterest == 5, "Person1 total interest should be $16.00\nWallet1 interest should be $11.00\nWallet2 interest should be $5.00");
        }

        [TestMethod]
        public void Test_Sen3()
        {
            Person p = new Person();
            p.FullName = "Person1";
            p.nWallets = 1;
            p.Wallets = new Wallet[p.nWallets];
            p.Wallets[0] = new Wallet();
            p.Wallets[0].NCards = 3;
            p.Wallets[0].Cards = new CreditCard[p.Wallets[0].NCards];
            p.Wallets[0].Cards[0] = new CreditCard();
            p.Wallets[0].Cards[0].Balance = 100;
            p.Wallets[0].Cards[0].Type = CreditCard.CreditCardType.Visa;
            p.Wallets[0].Cards[0].Interest = 10;
            p.Wallets[0].Cards[1] = new CreditCard();
            p.Wallets[0].Cards[1].Balance = 100;
            p.Wallets[0].Cards[1].Type = CreditCard.CreditCardType.MC;
            p.Wallets[0].Cards[1].Interest = 5;
            p.Wallets[0].Cards[2] = new CreditCard();
            p.Wallets[0].Cards[2].Balance = 100;
            p.Wallets[0].Cards[2].Type = CreditCard.CreditCardType.Discover;
            p.Wallets[0].Cards[2].Interest = 1;
            p.InterestCalculation();

            Person p2 = new Person();
            p2.FullName = "Person2";
            p2.nWallets = 1;
            p2.Wallets = new Wallet[p2.nWallets];
            p2.Wallets[0] = new Wallet();
            p2.Wallets[0].NCards = 2;
            p2.Wallets[0].Cards = new CreditCard[p2.Wallets[0].NCards];
            p2.Wallets[0].Cards[0] = new CreditCard();
            p2.Wallets[0].Cards[0].Balance = 100;
            p2.Wallets[0].Cards[0].Type = CreditCard.CreditCardType.Visa;
            p2.Wallets[0].Cards[0].Interest = 10;
            p2.Wallets[0].Cards[1] = new CreditCard();
            p2.Wallets[0].Cards[1].Balance = 100;
            p2.Wallets[0].Cards[1].Type = CreditCard.CreditCardType.MC;
            p2.Wallets[0].Cards[1].Interest = 5;

            p2.InterestCalculation();

            Assert.IsTrue(p.TotalInterest == 16 && p.Wallets[0].WInterest == 16 && p2.TotalInterest == 15 && p2.Wallets[0].WInterest == 15, "Person1 total interest should be $16.00\nWallet1 interest should be $16.00\nPerson2 total interest should be $15.00\nWallet1 interest should be $15.00");
        }
    }
}
