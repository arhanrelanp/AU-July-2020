using System;

public class Leaves
{
    public delegate void Notify();              // delegate
    public event Notify ProcessCompleted;       // event
    public int NoOfLeaves;
    public int AvailLeaves;

    public Leaves(int lr, int la)
    {
        NoOfLeaves = lr;
        AvailLeaves = la;
    }


    public void verify()
    {
        Console.WriteLine("Application process started!");
        if (AvailLeaves >= NoOfLeaves)
        {
            ProcessCompleted?.Invoke();
        }
        else
        {
            Console.WriteLine("Leaves not available.");
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter Number of leaves required .");
            int l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number of available leaves .");
            int a = Convert.ToInt32(Console.ReadLine());

            Leaves app = new Leaves(l, a);
            app.ProcessCompleted += ApplChecked; // register with an event
            app.verify();
        }

        // event handler
        public static void ApplChecked()
        {
            Console.WriteLine("Confirm please(Y/N)");
            String resp = Console.ReadLine();
            if (resp.Equals("Y"))
            {
                Console.WriteLine("Leave application submitted to manager!!");
            }
            else
            {
                Console.WriteLine("Leave application cancelled");
            }
            Console.ReadLine();
        }
    }


}