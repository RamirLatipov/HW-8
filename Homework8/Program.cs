using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\nВыберите задачу: 1 — упражнение 8.1, 2 — 8.2, 3 — 8.3, 4 — 8.4");
            Console.WriteLine("5 — домашнее 8.1, 6 — домашнее 8.2, 7 — сотрудники, 0 — выход");
            string choice = Console.ReadLine() ?? "0";
            switch (choice)
            {
                case "1": Exercise81.Run(); break;
                case "2": Exercise82.Run(); break;
                case "3": Exercise83.Run(); break;
                case "4": Exercise84.Run(); break;
                case "5": Homework81.Run(); break;
                case "6": Homework82.Run(); break;
                case "7": Office.Run(); break;
                case "0": return;
                default: Console.WriteLine("Нет такого пункта."); break;
            }
        }
    }
}
