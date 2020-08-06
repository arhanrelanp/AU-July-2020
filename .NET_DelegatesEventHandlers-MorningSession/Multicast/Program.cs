using System;


namespace DelegatesEventHandlers
{
    
    class Multicast
    {
        public delegate void concat(string s1, string s2);
        private string property;
        public void f1(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                property = property + s1;
            else
                property = property + s2;
        }
        public void f2(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                property = property + s1;
            else
                property = property + s2;
        }
        public void strconcat()
        {
            concat c;
            c = f1;
            c += f2;

            Console.WriteLine("String 1: ");
            string a = Console.ReadLine();
            Console.WriteLine("String 2: ");
            string b = Console.ReadLine();
            c(a, b);
            Console.WriteLine("Value of concatenated longer string is: " + property);
        }

    }
    class Program
    {
 
        public static void Main(string[] args)
        {

            Multicast m = new Multicast();
            m.strconcat();

        }
    }
}
