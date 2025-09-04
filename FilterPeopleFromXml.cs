using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;

public class XmlFiltre
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        var doc = XDocument.Parse(xmlData);
        var peoples = doc.Descendants("Person");

        List<string> isimler = new List<string>();
        int toplamMaas = 0;
        int enYuksekMaas = 0;
        int sayac = 0;

        foreach (var people in peoples)
        {
            string name = people.Element("Name")?.Value;
            int age = int.Parse(people.Element("Age")?.Value ?? "0");
            string dept = people.Element("Department")?.Value;
            int salary = int.Parse(people.Element("Salary")?.Value ?? "0");
            DateTime hireDate = DateTime.Parse(people.Element("HireDate")?.Value);

            if (age > 30 && dept == "IT" && salary > 5000 && hireDate.Year < 2019)
            {
                isimler.Add(name);
                toplamMaas += salary;
                if (salary > enYuksekMaas)
                {
                    enYuksekMaas = salary;
                }
                sayac++;
            }
        }

        isimler.Sort();

        int ortalama = sayac > 0 ? toplamMaas / sayac : 0;

        var sonuc = new
        {
            Names = isimler,
            TotalSalary = toplamMaas,
            AverageSalary = ortalama,
            MaxSalary = enYuksekMaas,
            Count = sayac
        };

        return JsonSerializer.Serialize(sonuc);
    }
}
