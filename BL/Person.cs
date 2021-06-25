using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        [Required]
        public string Aadhaar { get; set; }

        [Range(18,99)]
        public int Age { get; set; }
        public string Name { get; set; }

        [EmailAddress]
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

        static List<Person> _people = new List<Person>();   //stays in memory for application's lifetime
        public List<Person> GetAll()
        {
            if (Person._people.Count == 0)
            {
                Person._people.Add(new Person() { Name = "Meena", Age = 25, Email = "meena@danske.com" });
                Person._people.Add(new Person() { Name = "Teena", Age = 27, Email = "teena@danske.com" });
                Person._people.Add(new Person() { Name = "Sheena", Age = 30, Email = "sheena@danske.com" });
            }
            
            return _people;
        }

        public Person Find(string name)
        {
            //foreach (var item in Person._people)
            //{
            //    if (item.Name.ToLower() == name.ToLower())
            //    {
            //        return item;
            //    }
            //}

            return Person._people.Find((p) => p.Name.ToLower() == name.ToLower());

        }

        public bool Add(Person p)
        {
            try
            {
                Person._people.Add(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                return false;
            }
            return true;
            
        }

        public Person Update(string nametobefound, Person p)
        {
            Person tobeupdated =Find(nametobefound);
            tobeupdated.Age = p.Age;
            tobeupdated.Email = p.Email;
            tobeupdated.HasFace = p.HasFace;
            tobeupdated.HasHands = p.HasHands;
            tobeupdated.HasIQ = p.HasIQ;
            tobeupdated.HasLegs = p.HasLegs;
            tobeupdated.PersonGender = p.PersonGender;
            return tobeupdated;
        }


        //destructor
        ~Person()
        {
        }

    }
}
