using System;
using System.Linq;
using AlwaysEncrypted.DataAccess;

namespace AlwaysEncrypted
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            DimEmployee firstEmployee = context.DimEmployee.FirstOrDefault();
            Console.WriteLine($"Login ID : {firstEmployee.LoginId}");

            context.DimEmployee.Add(new DimEmployee
            {
                FirstName = "Uğur",
                LastName = "Demir",
                NameStyle = false,
                SalariedFlag = false,
                LoginId = "adventure-works\\uurdemir"

            });

            context.SaveChanges();
        }
    }
}
