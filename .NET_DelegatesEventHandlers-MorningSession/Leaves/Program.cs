using System;

namespace DelegatesEventHandlers
{
    public class Leaves
    {
        public delegate void Notify();
        public event Notify ProcessCompleted;
        public int NoOfLeaves;
        public int AvailLeaves;

        public Leaves(int lr, int la)
        {
            NoOfLeaves = lr;
            AvailLeaves = la;
        }


        public void verify()
        {
            Console.WriteLine("Leave application process Started!");
            if (AvailLeaves >= NoOfLeaves)
            {
                ProcessCompleted?.Invoke();
            }
            else
            {
                Console.WriteLine("Leaves not available! Apply for a shorter leave");
            }
        }



    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter Number of leaves required .");
            int lr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number of available leaves .");
            int la = Convert.ToInt32(Console.ReadLine());

            Leaves appln = new Leaves(lr, la);
            //Registered with an event
            appln.ProcessCompleted += appln_ProcessCompleted;
            appln.verify();
        }
        public static void appln_ProcessCompleted()
        {
            Console.WriteLine("Confirm please(Y/N)");
            String resp = Console.ReadLine();
            if (resp.Equals("Y") || resp.Equals("y"))
            {
                Console.WriteLine("Applied for leave successfully!!");
            }
            else
            {
                Console.WriteLine("Leave application cancelled!");
            }
            Console.ReadLine();
        }
    }
}




