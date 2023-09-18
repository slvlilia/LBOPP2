using System;

class BankAccount
{
    public string AccountNumber { get; }
    public double Balance { get; private set; }

    public BankAccount(string accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума поповнення повинна бути бiльше нуля.");
        }
        else
        {
            Balance += amount;
            Console.WriteLine($"Рахунок {AccountNumber}: Успiшно поповнено на {amount} грн.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сума зняття повинна бути бiльше нуля.");
        }
        else if (amount > Balance)
        {
            Console.WriteLine("На рахунку недостатньо коштiв для зняття.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Рахунок {AccountNumber}: Успiшно знято {amount} грн.");
        }
    }

    public void ShowAccountInfo()
    {
        Console.WriteLine($"Номер рахунку: {AccountNumber}");
        Console.WriteLine($"Поточний баланс: {Balance} грн.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введiть номер рахунку: ");
        string accountNumber = Console.ReadLine();

        Console.Write("Введiть початковий баланс: ");
        if (!double.TryParse(Console.ReadLine(), out double initialBalance))
        {
            Console.WriteLine("Неправильний формат балансу.");
            return;
        }

        // Створення об'єкту класу "Банківський рахунок"
        BankAccount account = new BankAccount(accountNumber, initialBalance);

        Console.WriteLine("\nIнформацiя про рахунок:");

        while (true)
        {
            Console.WriteLine("\nОберiть дiю:");
            Console.WriteLine("1. Поповнити рахунок");
            Console.WriteLine("2. Зняти грошi");
            Console.WriteLine("3. Показати iнформацiю про рахунок");
            Console.WriteLine("4. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введiть суму для поповнення: ");
                    if (double.TryParse(Console.ReadLine(), out double depositAmount))
                    {
                        account.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Неправильний формат суми.");
                    }
                    break;
                case "2":
                    Console.Write("Введiть суму для зняття: ");
                    if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                    {
                        account.Withdraw(withdrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("Неправильний формат суми.");
                    }
                    break;
                case "3":
                    account.ShowAccountInfo();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неправильний вибiр. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
