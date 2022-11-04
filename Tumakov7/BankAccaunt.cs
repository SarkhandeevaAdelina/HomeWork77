using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov7
{
    public enum AccountType { Current, Saving };

    class BankAccount
    {
        private long number;
        private double balance;
        private AccountType accountType;
        private static long id;
        private Queue tranQueue = new Queue();
        public BankAccount()
        {
            number = ID();
            accountType = AccType();
            balance = 0;
        }
        public static long ID()
        {
            return id++;
        }
        public AccountType AccType()
        {
            return accountType;
        }
        public double Balance()
        {
            return balance;
        }
        public BankAccount(AccountType accountType)
        {
            number = ID();
            this.accountType = accountType;
            balance = 0;
            Console.WriteLine($"Тип банковского счета:{accountType}; Номер счета:{number}");
        }
        public BankAccount(double balance)
        {
            number = ID();
            this.balance = balance;
            accountType = AccType();
            Console.WriteLine("Ваш баланс:" + balance);
        }
        public BankAccount(AccountType accountType, double balance)
        {
            number = ID();
            this.accountType = accountType;
            this.balance = balance;
            ID();
            Console.WriteLine($"Ваш баланс: {balance};  Тип банковского счета: {accountType}; Номер банковского счета: {number}");
        }
        public Queue Transactions()
        {
            return tranQueue;
        }
        public double Deposit(double summa, BankAccount bankAccount)
        {
            balance += summa;
            BankTransaction bankTransaction = new BankTransaction(summa);
            tranQueue.Enqueue(bankTransaction);
            return balance;
            Console.WriteLine($"Произошла операция: {bankTransaction}; Ваш баланс:{balance}");
        }
        public double WithDrow(double summa, BankAccount bankAccount)
        {
            if (balance >= summa)
            {
                balance -= summa;
                BankTransaction bankTransaction = new BankTransaction(-summa);
                tranQueue.Enqueue(bankTransaction);
                Console.WriteLine($"Произошла операция: {bankTransaction}; Ваш баланс:{balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
            }
            return balance;
        }
        public void Dispose()
        {
            StreamWriter addValue = File.AppendText("Transactions.txt");
            addValue.WriteLine("id аккаунта " + number);
            addValue.WriteLine("Баланс на счету:" + balance);
            addValue.WriteLine("Тип счета" + accountType);
            foreach (BankTransaction tran in tranQueue)
            {
                addValue.WriteLine($"Время: {DateTime.Now}.  Сумма перевода: {tran.Summa()}");
            }
            addValue.Close();
            GC.SuppressFinalize(this);
        }
    
    }
}
