using System;
using System.IO;
static class Homework81
{
    public static void SearchMail(ref string s)
    {
        int separator = s.IndexOf('#');
        s = separator < 0 ? "" : s.Substring(separator + 1).Trim();
    }
    public static void Run()
    {
        Console.WriteLine("Домашнее задание 8.1. Введите путь к файлу (одна запись ФИО # e-mail на строку):");
        string input = Console.ReadLine() ?? "";
        if (!File.Exists(input)) { Console.WriteLine("Файл не существует."); return; }
        Console.WriteLine("Введите путь к файлу со списком адресов:");
        string output = Console.ReadLine() ?? "";
        try
        {
            if (Path.GetFullPath(input) == Path.GetFullPath(output)) { Console.WriteLine("Выходной файл должен отличаться от исходного."); return; }
            string[] lines = File.ReadAllLines(input);
            using (StreamWriter writer = new StreamWriter(output))
            {
                foreach (string line in lines)
                {
                    string mail = line;
                    SearchMail(ref mail);
                    if (mail != "") writer.WriteLine(mail);
                }
            }
            Console.WriteLine("Адреса записаны в " + Path.GetFullPath(output));
        }
        catch (Exception e) when (e is IOException || e is UnauthorizedAccessException || e is ArgumentException || e is NotSupportedException)
        { Console.WriteLine("Ошибка работы с файлом: " + e.Message); }
    }
}
