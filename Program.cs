using System;
using System.Collections.Generic;

public class Account
{
    public string Name { get; set; }
    public double Balance { get; set; }

    public Account(string name = "Unnamed Account", double balance = 0.0)
    {
        Name = name;
        Balance = balance;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount < 0)
            return false;

        Balance += amount;
        return true;
    }

    public virtual bool Withdraw(double amount)
    {
        if (Balance - amount >= 0)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Name} - Balance: {Balance}";
    }
}


public class SavingsAccount : Account
{
    public double InterestRate { get; set; }

    public SavingsAccount(
        string name = "Unnamed Savings Account",
        double balance = 0.0,
        double interestRate = 0.0)
        : base(name, balance)
    {
        InterestRate = interestRate;
    }
}


public class CheckingAccount : Account
{
    private const double WithdrawalFee = 1.50;

    public CheckingAccount(
        string name = "Unnamed Checking Account",
        double balance = 0.0)
        : base(name, balance)
    {
    }

    public override bool Withdraw(double amount)
    {
        double totalAmount = amount + WithdrawalFee;

        if (Balance - totalAmount >= 0)
        {
            Balance -= totalAmount;
            return true;
        }

        return false;
    }
}


public class TrustAccount : Account
{
    public double InterestRate { get; set; }

    private int WithdrawalCount = 0;

    public TrustAccount(
        string name = "Unnamed Trust Account",
        double balance = 0.0,
        double interestRate = 0.0)
        : base(name, balance)
    {
        InterestRate = interestRate;
    }

    public override bool Deposit(double amount)
    {
        if (amount < 0)
            return false;

        Balance += amount;

        if (amount >= 5000)
        {
            Balance += 50;
        }

        return true;
    }

    public override bool Withdraw(double amount)
    {
        if (WithdrawalCount >= 3)
            return false;

        if (amount >= Balance * 0.20)
            return false;

        if (amount > Balance)
            return false;

        Balance -= amount;
        WithdrawalCount++;

        return true;
    }
}


public static class AccountUtil
{
    public static void Deposit(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Depositing ===");

        foreach (Account account in accounts)
        {
            if (account.Deposit(amount))
                Console.WriteLine($"Deposited {amount} to {account}");
            else
                Console.WriteLine($"Failed Deposit of {amount} to {account}");
        }
    }


    public static void Withdraw(List<Account> accounts, double amount)
    {
        Console.WriteLine("\n=== Withdrawing ===");

        foreach (Account account in accounts)
        {
            if (account.Withdraw(amount))
                Console.WriteLine($"Withdrew {amount} from {account}");
            else
                Console.WriteLine($"Failed Withdrawal of {amount} from {account}");
        }
    }
}


internal class Program
{
    static void Main(string[] args)
    {
        var accounts = new List<Account>();

        accounts.Add(new Account());
        accounts.Add(new Account("Larry"));
        accounts.Add(new SavingsAccount("Superman", 2000, 5.0));
        accounts.Add(new CheckingAccount("Moe", 2000));
        accounts.Add(new TrustAccount("Wonderwoman", 5000, 5.0));

        AccountUtil.Deposit(accounts, 1000);

        AccountUtil.Withdraw(accounts, 500);

    }
}