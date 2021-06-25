using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinApp
{
    //delegate <function declaration syntax>
    delegate int Compute(int[] ints);
    delegate double ComputeD(double[] ints);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UseGenericDelegates();
            Console.WriteLine("###### THIS IS A CONSOLE.WRITELINE() TO BE SEEN IN THE OUTPUT WINDOW ######");
        }

        private void UseGenericDelegates()
        {
            Func<int[], int> modernFunDel = new Func<int[], int>(Add);
           MessageBox.Show("==== Output of Func<int[],int> with Named function ====" + 
                                    modernFunDel(new int[] { 1,2,3,4,5}));

            //Using Lambdas in Func<>

            Func<int[], int> modernFunLamda = new Func<int[], int>(nums => nums.Sum());
            MessageBox.Show("==== Output of Func<int[],int> with Named function ===="+
                                modernFunLamda(new int[] { 1, 2, 3, 4, 5 }));

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;
            button1.Click += Button1_ClickedTwice;
            button1.Click += (object s, EventArgs ev) => { MessageBox.Show("Button1 Clicked anonymously!"); };

           
            Button myButton = new Button();
            myButton.Text = "My Button";
            myButton.Click += MyButton_Click;
            Controls.Add(myButton);
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyButton Clicked!");
        }

        private void Button1_ClickedTwice(object sender, EventArgs e)
        {
            Compute Addtions = new Compute(Add);    //named function way
            Compute AddWay2 = new Compute((nums) => nums.Sum());    //anonymous function as parameter to delegate instantiation
            Compute AddWay3 = (nums) => nums.Sum(); //Shortest way

            MessageBox.Show("You clicked Button 1 - Subscriber Button1_ClickedTwice");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked button 1 - Subscriber Button1_Click");
            //Instantiate my custom delegate "Compute"
            Compute Additions = new Compute(Add);
            Additions += (int[] nums) => {
                                            int result = 0;
                                            foreach (var item in nums)
                                            {
                                                result += item;
                                            }
                                            result *= -1;   //result = result * (-1)
                                            return result;
                                        };

            Additions += (nums) => nums.Sum();
            Additions += nums => nums.Sum();


            //Invoke the delegate "Compute"
            int[] ints = { 10, 20, 30, 40, 50 };
            int finalResult = Additions(new int[] { 1, 2, 3, 4, 5 });           
            MessageBox.Show("Clicked on Button1_Click. Calculated Sum of nums: " + Additions(new int[] { 10, 20, 30, 40, 50 }));

            //Invoke a particular method from delegate method list
            Delegate[] delegateMethods =Additions.GetInvocationList();
            MessageBox.Show(delegateMethods[1].DynamicInvoke(ints).ToString());


            //WIth double
            ComputeD dCompute = new ComputeD(AddDouble);
            dCompute += nums => nums.Sum();
        }

        private double AddDouble(double[] ints)
        {
            throw new NotImplementedException();
        }

        private int Add(int[] ints)
        {
            int result = 0;
            foreach (var item in ints)
            {
                result += item;
            }
            return result;
        }
    }
}
