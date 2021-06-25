using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//For .Net Framework (OLD)
namespace FirstNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello c#");
            var str =Console.ReadLine();
            Greet(str);

            //Let the screen stay until I press some key
            Console.ReadKey();
        }

        private static void Greet(string str)
        {
            Console.WriteLine("Guten Morgen {0}", str);
        }
    }
}
