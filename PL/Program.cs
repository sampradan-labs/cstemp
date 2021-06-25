using BL;
using System;
using System.IO;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Jon = new Person(Gender.Male);
            CreatePerson(Jon, "AA29384ZZ", "Jon", 29, Gender.Male, "jon@danske.com");

            Person Bon = new Person(Gender.Male);
            CreatePerson(Bon, "BB29384YY", "Bon", 28, Gender.Male, "bon@danske.com");

            Person Don = new Employee() { Designation="Architect"};
            ((Employee)Don).EmployeeId = 1001;  //Typecasting
            CreatePerson(Don, "CC29384XX", "Don", 30, Gender.Male, "don@danske.com");

            //Work with Abstract classes
            Shape sh = new Circle();
            DrawShapes(sh);
            DrawShapes(new Square());

            //Call interface methods
            IOperations ops = new FileOps();
            CallCreate(ops);
            CallCreate(new DbObs());

            IOperationsV2 v2 = new DbObs();
            v2.Merge();

            //Call Accessors
            //Not possible case
            //Person emp = new Person();
            //emp.Savings

            Employee emp = new Employee();
            emp.TryWithAccessors();

            //Read from IO
            Streams();

            ///let the console output stay visible
            ///
            Console.ReadKey();
        }

        private static void CallCreate(IOperations ops)
        {
            ops.Create();
            ops.Read();
            ops.Write();
            ops.Delete();
        }

        private static void DrawShapes(Shape sh)
        {
            //Runtime Polymorphism
            sh.Draw();
        }

        private static void CreatePerson(Person p, string aadhar, string name, int age, Gender personGender, string email)
        {
            p.Name = name;
            p.Age = age;
            p.PersonGender = personGender;
            p.Email = email;
            p.Aadhaar = aadhar;

            Console.WriteLine("======= Displaying person Details =======");
            Console.WriteLine("Name : {0}", p.Name);
            Console.WriteLine("Aadhar : {0}", p.Aadhaar);
            Console.WriteLine("Age : {0}", p.Age);
            Console.WriteLine("Gender : {0}", p.PersonGender);
            Console.WriteLine("Email : {0}", p.Email);
            Console.WriteLine(p.Walks(10));
            Console.WriteLine(p.Talks("I'm waiting for a lunch break ;-)"));

            ///Working with virtual & Override - Works()
            ///
            Console.WriteLine("{0} work Completion?: {1}"
                            ,p.Name, p.Works(new string[] {"Coding", "Training" }));

            

        }
    
        private static void Streams()
        {
            StreamReader reader = new StreamReader(@"F:\sample.txt");
            Console.WriteLine("Printing contents of a file");
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            StreamWriter writer = new StreamWriter(@"F:\sample.txt");
            writer.WriteLine(true);
            writer.Close();
            
        }
        
    }
}
