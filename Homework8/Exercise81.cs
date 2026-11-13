using System;

enum AccountType { Current, Savings }

class BankAccount
{
    private static int nextNumber = 1;
    private readonly int number;
    private decimal balance;
    private AccountType type;

    public BankAccount(decimal balance, AccountType type)
    {
        number = GenerateNumber();
        SetBalance(balance);
        SetType(type);
    }
    private static int GenerateNumber() { return nextNumber++; }
    public int GetNumber() { return number; }
    public decimal GetBalance() { return balance; }
    public AccountType GetAccountType() { return type; }
    public void SetBalance(decimal value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        balance = value;
    }
    public void SetType(AccountType value) { type = value; }
    public void Deposit(decimal amount) { if (amount > 0) balance += amount; }
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance) return false;
        balance -= amount;
        return true;
    }
    // Метод вызывается у получателя; source — счет, с которого снимают деньги.
    public bool TransferFrom(BankAccount source, decimal amount)
    {
        if (source == null || source == this || !source.Withdraw(amount)) return false;
        Deposit(amount);
        return true;
    }
    public void Print()
    {
        string typeName = GetAccountType() == AccountType.Current ? "текущий" : "сберегательный";
        Console.WriteLine($"Счёт №{GetNumber()}, тип: {typeName}, баланс: {GetBalance()}");
    }
}

static class Exercise81
{
    public static void Run()
    {
        Console.WriteLine("Упражнение 8.1. Перевод между счетами.");
        BankAccount first = new BankAccount(1000, AccountType.Current);
        BankAccount second = new BankAccount(200, AccountType.Savings);
        first.Print(); second.Print();
        Console.WriteLine("Перевод 300 с первого счёта на второй: " + (second.TransferFrom(first, 300) ? "выполнен" : "отклонен"));
        first.Print(); second.Print();
        Console.WriteLine("Попытка перевести 2000: " + (second.TransferFrom(first, 2000) ? "выполнена" : "недостаточно средств или неверная сумма"));
    }
}
