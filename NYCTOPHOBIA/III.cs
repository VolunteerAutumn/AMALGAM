using System;

namespace epstein_files_csharp_edition
{
    class CreditCard
    {
        public string CardNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string PIN { get; private set; }
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; private set; }

        public event Action? MoneyAdded;
        public event Action? MoneySpent;
        public event Action? CreditStarted;
        public event Action? TargetAmountReached;
        public event Action? PinChanged;

        public CreditCard(string cardNumber, string ownerName, DateTime expirationDate, string pin, decimal creditLimit, decimal balance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ExpirationDate = expirationDate;
            PIN = pin;
            CreditLimit = creditLimit;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            Balance += amount;
            MoneyAdded?.Invoke();
        }

        public void Spend(decimal amount)
        {
            if (amount <= 0) return;
            decimal oldBalance = Balance;
            if (Balance - amount < -CreditLimit)
            {
                Console.WriteLine("Credit limit exceeded!");
                return;
            }
            Balance -= amount;
            MoneySpent?.Invoke();
            if (oldBalance >= 0 && Balance < 0)
            {
                CreditStarted?.Invoke();
            }
        }

        public void ChangePIN(string newPin)
        {
            PIN = newPin;
            PinChanged?.Invoke();
        }

        public void CheckTargetAmount(decimal target)
        {
            if (Balance >= target)
            {
                TargetAmountReached?.Invoke();
            }
        }

        public override string ToString()
        {
            return $"Owner: {OwnerName}\nCard Number: {CardNumber}\nExpiration Date: {ExpirationDate:d}\nBalance: {Balance}\nCredit Limit: {CreditLimit}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard("2324-0990-0100-1335", "Yevpalampiy Vadimovich", new DateTime(2026, 11, 06), "0517", 5000, 1000);

            card.MoneyAdded += () => Console.WriteLine("EVENT: Account replenished.");
            card.MoneySpent += () => Console.WriteLine("EVENT: Money spent.");
            card.CreditStarted += () => Console.WriteLine("EVENT: Credit funds are now being used.");
            card.TargetAmountReached += () => Console.WriteLine("EVENT: Target amount reached.");
            card.PinChanged += () => Console.WriteLine("EVENT: PIN changed.");

            Console.WriteLine(card);
            Console.WriteLine();
            card.Deposit(2000);
            Console.WriteLine();
            card.Spend(1500);
            Console.WriteLine();
            card.Spend(2000);
            Console.WriteLine();
            card.ChangePIN("9999");
            Console.WriteLine();
            card.CheckTargetAmount(1000);
            Console.WriteLine();
            Console.WriteLine(card);
        }
    }
}
