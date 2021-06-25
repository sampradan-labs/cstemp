using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BL
{
    //Create a custom datatype called "Gender"
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        //default constructor
        public Person()
        {

        }
        //parameterized constructor
        public Person(Gender pGender)
        {
            this.PersonGender = pGender;
            this.HasIQ = true;
            this.HasFace = true;
            this.HasHands = true;
            this.HasLegs = true;

        }

        //public Person(name, gender)
        //{

        //}

        //Properties
        public string Aadhaar { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender PersonGender { get; set; }

        private string Secrets { get; set; }     //do not share it outside this scope
        protected double Savings { get; set; }  //share info only with derived class

        public bool HasHands { get; set; }
        public bool HasLegs { get; set; }
        public bool HasIQ { get; set; }
        public bool HasFace { get; set; }

        /// <summary>
        /// METHODS
        /// </summary>

        public string Walks(int steps)
        {
            return this.Name + " walks " + 
                            steps.ToString() + 
                            " steps";
        }

        public string Talks(string words)
        {
            return this.Name + " says: " + words;
        }

        public bool Works()
        {
            return true;
        }
       
        public virtual bool Works(string[] tasks)
        {
            foreach (var item in tasks)
            {
                Console.WriteLine("Task: {0} is completed", item);
            }
            return true;
        }

        //destructor
        ~Person()
        {
        }

    }
}
