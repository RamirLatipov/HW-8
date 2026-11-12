using System;
static class Exercise84
{
    public static void Check(object value)
    {
        bool isFormattable = value is IFormattable;
        IFormattable? formatted = value as IFormattable;
        Console.WriteLine($"{value}: is — {isFormattable}, as — {(formatted != null ? "реализует" : "не реализует")}");
        if (formatted != null) Console.WriteLine("Форматирование: " + formatted.ToString(null, null));
    }
    public static void Run()
    {
        Console.WriteLine("Упражнение 8.4. Проверка интерфейса IFormattable операторами is и as.");
        Check(123); Check(DateTime.Today); Check("строка");
    }
}
