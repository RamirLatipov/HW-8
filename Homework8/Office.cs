using System;
using System.Collections.Generic;

enum Department { Management, Systems, Developers, Other }

class Employee
{
    public string Name;
    public Department Department;
    private List<Employee> managers = new List<Employee>();
    public Employee(string name, Department department) { Name = name; Department = department; }
    public void AddManager(Employee manager) { managers.Add(manager); }
    public bool Accepts(Employee sender, OfficeTask task)
    {
        return managers.Contains(sender) && Department == task.Target;
    }
}
class OfficeTask
{
    public string Name;
    public Department Target;
    public OfficeTask(string name, Department target) { Name = name; Target = target; }
}
static class Office
{
    static void Give(Employee sender, Employee receiver, OfficeTask task)
    {
        Console.WriteLine($"{sender.Name} даёт задачу «{task.Name}» сотруднику {receiver.Name}: " +
            (receiver.Accepts(sender, task) ? "берёт задачу" : "не берёт задачу"));
    }
    public static void Run()
    {
        Console.WriteLine("Задача про сотрудников. Проверка прямого руководителя и направления задачи.");
        Employee timur = new Employee("Тимур", Department.Other);
        Employee rashid = new Employee("Рашид", Department.Other);
        Employee ilham = new Employee("О Ильхам", Department.Other);
        Employee lukas = new Employee("Лукас", Department.Other);
        Employee arkady = new Employee("Оркадий", Department.Management);
        Employee volodya = new Employee("Володя", Department.Management);
        Employee ilshat = new Employee("Ильшат", Department.Systems);
        Employee ivanych = new Employee("Иваныч", Department.Systems);
        Employee sergey = new Employee("Сергей", Department.Developers);
        Employee laysan = new Employee("Ляйсан", Department.Developers);
        rashid.AddManager(timur); ilham.AddManager(timur); lukas.AddManager(rashid);
        arkady.AddManager(ilham); volodya.AddManager(arkady);
        ilshat.AddManager(arkady); ilshat.AddManager(volodya); ivanych.AddManager(ilshat);
        sergey.AddManager(arkady); sergey.AddManager(volodya); laysan.AddManager(sergey);
        List<Employee> systems = new List<Employee>();
        foreach (string name in new string[] { "Илья", "Витя", "Женя" })
        { Employee person = new Employee(name, Department.Systems); person.AddManager(ivanych); systems.Add(person); }
        List<Employee> developers = new List<Employee>();
        foreach (string name in new string[] { "Марат", "Дина", "Ильдар", "Антон" })
        { Employee person = new Employee(name, Department.Developers); person.AddManager(laysan); developers.Add(person); }
        OfficeTask network = new OfficeTask("Настроить сеть", Department.Systems);
        OfficeTask app = new OfficeTask("Создать программу", Department.Developers);
        OfficeTask plan = new OfficeTask("Составить план отдела", Department.Management);
        Give(ilham, arkady, plan);
        Give(arkady, volodya, plan);
        Give(volodya, sergey, app);
        Give(sergey, laysan, app);
        foreach (Employee developer in developers) Give(laysan, developer, app);
        Give(arkady, ilshat, network);
        Give(ilshat, ivanych, network);
        foreach (Employee system in systems) Give(ivanych, system, network);
        Give(lukas, developers[1], app); // Бухгалтерия не руководит разработчиками.
        Give(sergey, developers[1], app); // Начальник сектора не является прямым руководителем Дины.
        Give(laysan, developers[1], network); // Направление задачи не совпадает.
    }
}
