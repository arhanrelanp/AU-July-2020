using System;


namespace DelegatesEventHandlers
{

    class Program
    {
        public delegate int count(string s1, string s2);
        public static int charCount(string s1, string s2)
        {
            string res = s1 + s2;
            return res.Length;
        }
        static void Main(string[] args)
        {
            count c = new count(charCount);
            Console.WriteLine("String 1: ");
            string s1 = Console.ReadLine();
            Console.WriteLine("String 2: ");
            string s2 = Console.ReadLine();
            Console.WriteLine(s1 + " " + s2);
            Console.WriteLine("Length: " + c(s1, s2));

        }
    }
}