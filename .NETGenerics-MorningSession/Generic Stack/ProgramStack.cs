using System;
using System.Collections.Generic;
using System.Linq;

namespace Net_GenericStack
{
   public class cricketer
    {
        public int ID;
        public string Name;
        public string Role;
        public int Age;

    }
    
    public class demo{
        static void Main(string[] args)
        {
           cricketer c1=new cricketer(){
               ID=7,
               Name="Dhoni",
               Role="All-rounder",
               Age=35
           };
           cricketer c2=new cricketer(){
               ID=0,
               Name="Sehwag",
               Role="Batsman",
               Age=38
           };
           cricketer c3=new cricketer(){
               ID=13,
               Name="Kohli",
               Role="Batsman",
               Age=25
           };
           cricketer c4=new cricketer(){
               ID=4,
               Name="Nehra",
               Role="Bowler",
               Age=40
           };
           Stack<cricketer> s=new Stack<cricketer>();
            s.Push(c1);
            s.Push(c2);
            s.Push(c4);
            s.Push(c3);
            while(s.Any()){
                cricketer c = s.Peek();
                
                Console.WriteLine(c.Name);
                s.Pop();
            }
        }

        
    }
    
}