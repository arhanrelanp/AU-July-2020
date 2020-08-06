using System;


namespace ConsoleApp2
{
    class Addition
    {
        public delegate void Inform(int a, int b);
        //Event for the above delegate
        public event Inform EventTriggered;

        public void ProcessBegin()
        {
            int a, b;
            try
            {
                Console.WriteLine("Enter first number to be added");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number to be added");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nEnter to show sum");
                //This ensures that the sum is displayed only after enter is pressed
                Console.ReadLine();
                OnEventTriggered(a, b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected virtual void OnEventTriggered(int num1, int num2)
        {
            EventTriggered?.Invoke(num1, num2);
        }



    }
    class Program
    {
        //Subscriber Function to add two numbers
        public static void Sum(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Sum is : " + c);
        }
        static void Main(string[] args)
        {
            Addition add = new Addition();
            add.EventTriggered += Sum;
            add.ProcessBegin();
        }
    }
}