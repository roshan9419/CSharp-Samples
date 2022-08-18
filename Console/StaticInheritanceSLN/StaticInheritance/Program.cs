using System;

namespace StaticInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IContactInfo
    {
        string GetEmail();
        //static string GetContactNumber();
    }

    static class Company
    {
        public static string GetEmail()
        {
            return "";
        }
    }

    static class Example: Company
    {

    }

    class Example2: Company
    {

    }

}
