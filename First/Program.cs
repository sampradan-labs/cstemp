using System;   //to import namespaces
using System.Collections;
using System.Globalization;
//using First.SubSpace;

//.Net CORE
namespace First.SubSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
            Console.WriteLine("Current culture: {0}", CultureInfo.CurrentCulture.Name);
            Console.WriteLine("Hello World!");
            var str = Console.ReadLine();
            Greet(str);
            WorkWithTypes();
        }

        private static void Greet(string str)
        {
            //String Interpolation - using the $""
            Console.WriteLine($"Namaste {str}");
        }

        private static void WorkWithTypes()
        {
            int i = 100;
            int[] manyI = { 1, 2, 3, 4, 5 };
            string yourName = new string("String.Empty");   //new keyword to indicate new instance / new memory location
            object iDontKnow = new MyClass();
            //Print the above
            Console.WriteLine("i={0}, manyI={1}, yourName={2}, iDontKnow={3}", i, manyI, yourName, iDontKnow);

            //expandable array => Collections
            ArrayList generalList = new ArrayList();
            generalList.Add("A string");
            generalList.Add(1000);
            generalList.Add(10.5f);
            generalList.Add(1000.3243m);

            //Print a collection => Loops => ForEach
            Console.WriteLine("======== Printing a Collection =========");
            foreach (var item in generalList)
            {
                Console.WriteLine(item);
            }

            string option = Console.ReadLine();
            //1000
            double balance = Convert.ToDouble(Console.ReadLine());  //Type conversion
            balance = (double)100f; //type casting
            switch (option)
            {
                case "Register":
                    break;

                case "Credit":
                    break;

                case "Debit":
                    break;
                default:
                    break;
            }

        }


    }

    class MyClass
    {

    }

    class MyClass2
    {

    }

}

namespace First.AnotherSpace
{

    class MyClass3
    {

    }
}
