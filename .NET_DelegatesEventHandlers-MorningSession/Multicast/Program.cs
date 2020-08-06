﻿using System;


namespace DelegatesEventHandlers
{
    
    class Program
    {
        public delegate int count(string s1, string s2);
        public static int countChars(string s1, string s2)
        {
            string res = s1 + s2;
            return res.Length;
        }
        static void Main(string[] args)
        {
            count c = new count(countChars);
            Console.WriteLine("String 1: ");
            string a = Console.ReadLine();
            Console.WriteLine("String 2: ");
            string b = Console.ReadLine();
            Console.WriteLine(a + "" + b);
            Console.WriteLine("Length: " + c(a, b));

        }
    }
}