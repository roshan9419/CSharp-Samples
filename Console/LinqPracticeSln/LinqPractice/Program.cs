using LinqPractice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace LinqPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer( new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;

            var query1 = from car in db.Cars
                         orderby car.Combined descending, car.Name ascending
                         select car;

            foreach (var car in query1.Take(10))
            {
                Console.WriteLine($"{car.Name}, {car.Combined}");
            }
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static List<Car> ProcessCars(string fileName)
        {
            var query = File.ReadAllLines(fileName)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCars();

            return query.ToList();
        }

        private static void Linq()
        {
            string path = @"C:\windows";
            ShowFilesWithoutLinq(path);

            Console.WriteLine("\n*****************\n");

            ShowFilesWithLinq(path);
        }

        private static void ShowFilesWithoutLinq(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();

            // top large files
            Array.Sort(files, (a, b) => b.Length.CompareTo(a.Length));

            for (int i = 0; i < 5; i++)
            {
                var file = files[i];
                Console.WriteLine($"File: {file.FullName, -50} | Size: {file.Length}");
            }
        }

        private static void ShowFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            var query2 = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            var query3 = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Where(f => f.FullName.EndsWith("exe"))
                        .Take(5);

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"File: {file.FullName,-50} | Size: {file.Length}");
            }
        }
    }
}
