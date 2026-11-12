using System;
using System.Collections.Generic;
class Song
{
    private string name = "";
    private string author = "";
    private Song? prev;
    public void SetName(string name) { this.name = name; }
    public void SetAuthor(string author) { this.author = author; }
    public void SetPrevious(Song song) { prev = song; }
    public string Title() { return name + " — " + author; }
    public void Print() { Console.WriteLine(Title() + (prev == null ? " (первая песня)" : "; предыдущая: " + prev.Title())); }
    public override bool Equals(object? obj)
    {
        Song? other = obj as Song;
        return other != null && name == other.name && author == other.author;
    }
    public override int GetHashCode() { return HashCode.Combine(name, author); }
}
static class Homework82
{
    public static void Run()
    {
        Console.WriteLine("Домашнее задание 8.2. Список песен и сравнение первой со второй.");
        string[] names = { "Звезда по имени Солнце", "Группа крови", "Кукушка", "Пачка сигарет" };
        List<Song> songs = new List<Song>();
        for (int i = 0; i < names.Length; i++)
        {
            Song song = new Song(); song.SetName(names[i]); song.SetAuthor("Кино");
            if (i > 0) song.SetPrevious(songs[i - 1]);
            songs.Add(song);
        }
        foreach (Song song in songs) song.Print();
        Console.WriteLine("Первая и вторая песни равны: " + songs[0].Equals(songs[1]));
    }
}
