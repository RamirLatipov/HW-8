using System;
static class Exercise82
{
    public static string Reverse(string text)
    {
        char[] letters = text.ToCharArray();
        Array.Reverse(letters);
        return new string(letters);
    }
    public static void Run()
    {
        Console.WriteLine("Упражнение 8.2. Введите строку для перестановки символов в обратном порядке:");
        string text = Console.ReadLine() ?? "";
        Console.WriteLine("Результат: " + Reverse(text));
        Console.WriteLine("Проверка: Reverse(привет) = " + Reverse("привет"));
    }
}
