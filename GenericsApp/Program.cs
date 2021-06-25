using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Demo - Expandable Arrays -As ArrayList//
            CallArrayList();
            // Demo - Generics - As Lists //
            CallGenericList();

            //Demo - Using Func<>//
            CallGenericDelegate();
            //////
            Console.ReadKey();
        }

        private static void CallGenericDelegate()
        {
            Func<int[], int> compute = new Func<int[], int>(Add);
            Console.WriteLine("Func<int[], int> output (Named Method): {0}", compute(new int[] { 1, 2, 3 }));

            Func<int[], int> computeLambda = new Func<int[], int>((nums) => nums.Sum());
            Console.WriteLine("Func<int[], int> output (Lambda Method): {0}", computeLambda(new int[] { 1, 2, 3 }));

            //Action<>: Takes any kind / number of input parameters, returns void
            //Action<string> => (string s)=>{}
            Action<string> ClickMe = new Action<string>(OnClicking);
            ClickMe("Nihal");
            Action<string> ClickMeLambda = new Action<string>(
                                                               (click) => 
                                                                Console.WriteLine("Thanks {0}, Clicked through Lambda", click)
                                                            );
            ClickMeLambda("Nihal");

            //Predicate
            Predicate<string> CheckLength = new Predicate<string>((s) => s.Length > 0);
            Console.WriteLine("Check if not empty: Is not null?? : {0}",CheckLength("Navodita"));
            
        }

        private static void OnClicking(string obj)
        {
            Console.WriteLine("Thanks {0}, for clicking this service",obj);
        }

        private static int Add(int[] nums)
        {
            //CallGenericList2((str) => { Console.WriteLine("Ha ha ha"); });
            return nums.Sum();
            
        }

        //private static void CallGenericList2(Action<string> s) { }

        private static void CallGenericList()
        {
            //PrimaryType<sub-Type> yourVariableName = new PrimaryType<sub-Type>()
            List<string> nameList = new List<string>();
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "value");
            SortedDictionary<int, string> sd = new SortedDictionary<int, string>();
            sd.Add(10, "value");
            sd.Add(1, "new value");

            foreach (var item in sd)
            {
                Console.WriteLine("{0},{1}",item.Key, item.Value);
            }

            nameList.Add("Eena");
            nameList.Add("Meena");
            nameList.Add("Teena");
            //nameList.Add(1000); //Not allowed. Compile time error occurs

            foreach (var item in nameList)
            {
                Console.WriteLine("Item: {0} | Datatype: {1}", item, item.GetType().Name);
            }
            Console.WriteLine("#### Using Foreach Lambda ####");
            nameList.ForEach((s) => {
                                        Console.WriteLine("Item: {0} | Datatype: {1}", s, s.GetType().Name);
                                    });

            //nameList.Where
            
        }

        private static void CallArrayList()
        {
            ArrayList objectList = new ArrayList();
            objectList.Add(1000);
            objectList.Add("Meena");
            objectList.Add(new Program());

            try
            {
                double result = 0;
                foreach (var item in objectList)
                {
                    result = result + Convert.ToDouble(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred. Details: {0}", ex.Message);
                //throw ex;   //Throws this exception to the calling function
            }
            finally
            {
                //Add it to a file log
            }           

            
        }
    }
}
