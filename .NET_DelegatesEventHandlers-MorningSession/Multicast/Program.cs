using System;


namespace DelegatesEventHandlers
{
    class Multicast
    {
        public delegate void Concat(string s1, string s2);
        private string result;
        public Multicast()
        {
            result = "";
        }
        public void f1(string s1,string s2)
        {
            if (s1.Length > s2.Length)
                result = result + s1;
            else
                result = result + s2;
        }
        public void f2(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                result = result + s1;
            else
                result = result + s2;
        }
        public void StrConcat()
        {
            string a, b;
            Concat c;
            c = f1;
            c += f2;
            Console.WriteLine("String 1: ");
            a = Console.ReadLine();
            Console.WriteLine("String 2: ");
            b = Console.ReadLine();
            c(a, b);
            Console.WriteLine("Value of concatenated longer string is: " + result);

        }
    }
    class Program
    {
     
        static void Main(string[] args)
        {
            Multicast m = new Multicast();
            m.StrConcat();
        }
    }
}