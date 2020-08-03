using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Queries
    {
        //-----------Query 1: To count the number of vowels in an input string--------------------
        public void CountV()
        {
            string s= "";
            Console.WriteLine("Enter input string");
            s=Console.ReadLine().ToUpper();
            int c=s.Count(l=>"AEIOU".Contains(l));
            Console.WriteLine("Vowel count:"+c);
        }
        //-----------Query 2: To count the number of student names with "ee" in it------------------
        public void CountNames()
        {
            Console.WriteLine("Enter the number of student names");
            int n=Convert.ToInt32(Console.ReadLine());
            string[] snames= new string [n];
            Console.WriteLine("Enter the student names");
            for(int i=0; i< n;i++)
            {
                snames[i]=Console.ReadLine();
            }
            Console.WriteLine("Names with ee in it are:");
            IEnumerable<string> result=from s in snames
                        where s.Contains("ee")
                        select s;
            foreach(string name in result)
            {
                Console.WriteLine(name);
            }
        }
        //-------------Query 3: To join 2 lists on common attributes--------
        class singer
        {
            public string fname;
            public string lname;
            public int numofsongs;
        }
        class actor
        {
            public string fname;
            public string lname;
            public int numofmovies;
        }
        public void JoinList()
        {
            //The values have been hardcoded for demonstration purposes
            //List of singers
            List<singer> sin = new List<singer>{
                new singer {fname="Ayushman", lname="Khurana",numofsongs=10},
                new singer {fname="Sonu", lname="Nigam",numofsongs=13},
                new singer {fname="Arijit", lname="Singh",numofsongs=15}
            };
            //List of movies
            List<actor> act = new List<actor>{
                new actor {fname="Ayushman", lname="Khurana",numofmovies=6},
                new actor {fname="Shah", lname="Rukh Khan",numofmovies=13},
                new actor {fname="Salman", lname="Khan",numofmovies=15}
            };
            //Joining the 2 lists
            IEnumerable<string> result= from singer in sin
                                        join actor in act
                                        on new{singer.fname, singer.lname}
                                        equals new{actor.fname, actor.lname}
                                        select singer.fname+" "+singer.lname;
            foreach(string name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
    class Program{
    static void Main(string[] args)
    {
        //console.writeline("Hello world");
        Queries q=new Queries();
        Console.WriteLine("--------Query 1----------");
        q.CountV();
        Console.WriteLine("--------Query 2----------");
        q.CountNames();
        Console.WriteLine("--------Query 3----------");
        q.JoinList();
        
    }
}
}
