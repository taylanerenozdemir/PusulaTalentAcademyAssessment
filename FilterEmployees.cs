using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class EmployeeFilter
{
    public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        /*filtreleme islemi*/
        var filtered = employees
            .Where(e => e.Age >= 25 && e.Age <= 40)
            .Where(e => e.Department == "IT" || e.Department == "Finance")
            .Where(e => e.Salary >= 5000 && e.Salary <= 9000)
            .Where(e => e.HireDate.Year > 2017)
            .ToList();

        /*isimleri sıralam*/
        var names = filtered
            .Select(e => e.Name)
            .OrderByDescending(n => n.Length)
            .ThenBy(n => n)
            .ToList();

        
        decimal toplam = filtered.Any() ? filtered.Sum(e => e.Salary) : 0;
        decimal ort = filtered.Any() ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
        decimal min = filtered.Any() ? filtered.Min(e => e.Salary) : 0;
        decimal max = filtered.Any() ? filtered.Max(e => e.Salary) : 0;
        int count = filtered.Count;

        /*json veri tipine çevirme*/
        var result = new
        {
            Names = names,
            TotalSalary = toplam,
            AverageSalary = ort,
            MinSalary = min,
            MaxSalary = max,
            Count = count
        };

        return JsonSerializer.Serialize(result);
    }
}
