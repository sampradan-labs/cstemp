using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Employee : Person
    {
        public string Designation { get; set; }
        public int EmployeeId { get; set; }

        public override bool Works(string[] tasks)
        {
            string[] splits = new string[2];
            //"Coding Task,completed"
            foreach (var item in tasks)
            {
                if (item.Contains(','))
                {
                    splits=item.Split(',');
                }
                else
                {
                    //Coding task
                    splits[0] = item;
                    splits[1] = "Pending";
                }

                Console.WriteLine("{0} with Designation {1} has task {2} in {3} state",
                                    this.Name, this.Designation, splits[0], splits[1]);
            }

            return true;
        }

        public void TryWithAccessors()
        {
            this.Savings = 1000000d;
            Console.WriteLine("Accessing protected Savings from Employee {0}", 
                            this.Savings);
        }
    }


    public class A { }
    public class B : A { }
    public class C : B { }
}
