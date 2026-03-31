using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace C__MultiThread_Assignment
{
    class BankAccount
    {
        public int Balance;
        private object lockObject = new object();

        public BankAccount(int balance)
        {
            Balance = balance;
        }

        // Without synchronization
        public void WithdrawWithoutLock(int amount)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " trying to withdraw " + amount);

            if (Balance >= amount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " checked balance: " + Balance);
                Thread.Sleep(100); // simulate delay
                Balance = Balance - amount;
                Console.WriteLine(Thread.CurrentThread.Name + " completed withdrawal. Remaining Balance: " + Balance);
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " cannot withdraw. Insufficient balance: " + Balance);
            }
        }

        // With synchronization
        public void WithdrawWithLock(int amount)
        {
            lock (lockObject)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " trying to withdraw " + amount);

                if (Balance >= amount)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " checked balance: " + Balance);
                    Thread.Sleep(100); // simulate delay
                    Balance = Balance - amount;
                    Console.WriteLine(Thread.CurrentThread.Name + " completed withdrawal. Remaining Balance: " + Balance);
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " cannot withdraw. Insufficient balance: " + Balance);
                }
            }
        }
    }

    internal class Assignment2
    {
        static void Main()
        {
            Console.WriteLine("----- WITHOUT SYNCHRONIZATION -----");
            BankAccount account1 = new BankAccount(1000);

            Thread t1 = new Thread(() => account1.WithdrawWithoutLock(500));
            Thread t2 = new Thread(() => account1.WithdrawWithoutLock(500));
            Thread t3 = new Thread(() => account1.WithdrawWithoutLock(500));

            t1.Name = "Thread 1";
            t2.Name = "Thread 2";
            t3.Name = "Thread 3";

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Final Balance without lock: " + account1.Balance);

            Console.WriteLine("\n----- WITH SYNCHRONIZATION USING LOCK -----");
            BankAccount account2 = new BankAccount(1000);

            Thread t4 = new Thread(() => account2.WithdrawWithLock(500));
            Thread t5 = new Thread(() => account2.WithdrawWithLock(500));
            Thread t6 = new Thread(() => account2.WithdrawWithLock(500));

            t4.Name = "Thread 1";
            t5.Name = "Thread 2";
            t6.Name = "Thread 3";

            t4.Start();
            t5.Start();
            t6.Start();

            t4.Join();
            t5.Join();
            t6.Join();

            Console.WriteLine("Final Balance with lock: " + account2.Balance);
        }
    }
}
