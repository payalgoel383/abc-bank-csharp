﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class BankTest
    {

        private static readonly double DOUBLE_DELTA = 1e-2;

        [TestMethod]
        public void CustomerSummary() 
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            john.OpenAccount(new Account(Account.CHECKING));
            bank.AddCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.CustomerSummary());
        }

        [TestMethod]
        public void CheckingAccount() {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.CHECKING);
            Customer bill = new Customer("Bill").OpenAccount(checkingAccount);
            bank.AddCustomer(bill);

            checkingAccount.Deposit(100.0);
            
            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void SavingsAccount() {
            Bank bank = new Bank();
            Account savingsAccount = new Account(Account.SAVINGS);
            bank.AddCustomer(new Customer("Bill").OpenAccount(savingsAccount));

            savingsAccount.Deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void MaxiSavingsAccount() {
            Bank bank = new Bank();
            Account maxiAccount = new Account(Account.MAXI_SAVINGS);
            bank.AddCustomer(new Customer("Bill").OpenAccount(maxiAccount));

            maxiAccount.Deposit(3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void MaxiSavingsAccountInterestTest()
        {
            Bank bank = new Bank();
            Account maxiAccount = new Account(Account.MAXI_SAVINGS);
            bank.AddCustomer(new Customer("Bill").OpenAccount(maxiAccount));

            maxiAccount.Deposit(5000.0);
            maxiAccount.Deposit(5000.0);

            Assert.AreEqual(41.17, bank.totalInterestAccruedDaily(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void MaxiSavingsAccountInterestTest1()
        {
            Bank bank = new Bank();
            Account maxiAccount = new Account(Account.MAXI_SAVINGS);
            bank.AddCustomer(new Customer("Bill").OpenAccount(maxiAccount));

            maxiAccount.Deposit(10500.0);
            maxiAccount.Withdraw(500.0);

            Assert.AreEqual(0.82, bank.totalInterestAccruedDaily(), DOUBLE_DELTA);
        }

        [TestMethod]
        public void SavingsAccountInterestTest()
        {
            Bank bank = new Bank();
            Account savingsAccount = new Account(Account.SAVINGS);
            bank.AddCustomer(new Customer("Bill").OpenAccount(savingsAccount));

            savingsAccount.Deposit(10000.0);

            Assert.AreEqual(1.56, bank.totalInterestAccruedDaily(), DOUBLE_DELTA);
        }


        [TestMethod]
        public void CheckingAccountInterestTest()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.CHECKING);
            Customer bill = new Customer("Bill").OpenAccount(checkingAccount);
            bank.AddCustomer(bill);

            checkingAccount.Deposit(10000.0);

            Assert.AreEqual(0.82, bank.totalInterestAccruedDaily(), DOUBLE_DELTA);
        }
        
    }
}
