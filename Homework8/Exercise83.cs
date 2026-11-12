using System;
using System.IO;
static class Exercise83
{
    public static void Run()
    {
        Console.WriteLine("Упражнение 8.3. Введите путь к исходному текстовому файлу:");
        string path = Console.ReadLine() ?? "";
        if (!File.Exists(path)) { Console.WriteLine("Файл не существует."); return; }
        Console.WriteLine("Введите путь к выходному файлу:");
        string output = Console.ReadLine() ?? "";
        try
        {
            if (Path.GetFullPath(path) == Path.GetFullPath(output)) { Console.WriteLine("Выходной файл должен отличаться от исходного."); return; }
            string text = File.ReadAllText(path);
            File.WriteAllText(output, text.ToUpper());
            Console.WriteLine("Результат записан в " + Path.GetFullPath(output));
        }
        catch (Exception e) when (e is IOException || e is UnauthorizedAccessException || e is ArgumentException || e is NotSupportedException)
        { Console.WriteLine("Ошибка работы с файлом: " + e.Message); }
    }
}
