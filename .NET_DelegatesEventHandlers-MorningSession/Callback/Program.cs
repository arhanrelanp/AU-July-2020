using System;

//Callback to implement one class function from another class object
namespace Callback
{
    public class A
    {
        public string InputRead()
        {
            Console.WriteLine("Enter Input String");
            String s = Console.ReadLine();
            return s;
        }
    }
    public class B
    {
        private string Input;
        //Delegate declaration
        public delegate string GetInput();
        public GetInput GetInputString;
        public void ObtainInput()
        {
            Input = GetInputString();
            Console.WriteLine("The input is: " + Input);
        }
    }
    class Program
    {
        public static void Main (string[] args)
        {
            A obj1 = new A();
            B obj2 = new B();
            obj2.GetInputString = obj1.InputRead;
            obj2.ObtainInput();
        }
    }
}
