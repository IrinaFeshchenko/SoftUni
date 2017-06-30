using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        while (true)
        {
            var cmdArgs = Console.ReadLine().Split();
            if (cmdArgs[0] == "End") break;

            var cmdType = cmdArgs[0];

            if (cmdType == "Create")
            {
                Create(cmdArgs, accounts);
            }
            else if (cmdType == "Deposit")
            {
                Deposit(cmdArgs, accounts);
            }
            else if (cmdType == "Withdraw")
            {
                Withdraw(cmdArgs, accounts);
            }
            else if (cmdType == "Print")
            {
                Print(cmdArgs, accounts);
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine($"Account ID{id}, balance {accounts[id].Balance:f2}");
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = int.Parse(cmdArgs[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (amount > accounts[id].Balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            accounts[id].Withdraw(amount);
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = int.Parse(cmdArgs[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Deposit(amount);
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id, acc);
        }
    }
}

