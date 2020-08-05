using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class SQLQueries
    {
        SqlConnection con;
        string connectionString;
        SqlDataAdapter ad;
        DataSet ds;


        //Contructor initialises connection to the SQL server
        public SQLQueries()
        {
            connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
        }

        //Displays the content of employee table
        public void Display_Emp()
        {
            ad = new SqlDataAdapter("Select * from tempdb.dbo.employee", con);
            ds = new DataSet();
            ad.Fill(ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Console.WriteLine("Employee ID: " + ds.Tables[0].Rows[i]["id"] + " Employee Name:" + ds.Tables[0].Rows[i]["ename"] + " Department ID: " + ds.Tables[0].Rows[i]["deptid"]);
                }
            }
            else
            {
                Console.WriteLine("Employee Table Empty");
            }
        }
        //Display the content of Dept Table
        public void Display_Dept()
        {
            ad = new SqlDataAdapter("select * from tempdb.dbo.dept", con);
            ds = new DataSet();
            ad.Fill(ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Console.WriteLine("Department ID: " + ds.Tables[0].Rows[i]["id"] + " Department Name:" + ds.Tables[0].Rows[i]["dname"]);
                }
            }
            else
            {
                Console.WriteLine("Dept Table Empty");
            }
        }
        //Inserts user values into Dept Table using Stored Procedure Insert_Dept
        public void Insert_Dept()
        {
            string dep_id, dep_name;
            Console.WriteLine("\nEnter new Department ID : ");
            dep_id = Console.ReadLine();
            Console.WriteLine("\nEnter new Department Name: ");
            dep_name = Console.ReadLine();
            string sqlQuery = "execute tempdb.dbo.Insert_Dept " + "'" + dep_id + "'" + "," + "'" + dep_name + "'" + ";";
            int rowAffected = 0;
            SqlCommand command = new SqlCommand(sqlQuery, con);
            rowAffected = command.ExecuteNonQuery();

            if (rowAffected != 0)
            {
                Console.WriteLine("\nData Successfully Inserted\n");
            }
            else
            {
                Console.WriteLine("\nInsertion Failed\n");
            }
        }
        // Deletes the record of an employee by calling a stored procedure Delete_Emp 
        public void Del_Employee()
        {
            string empid;
            Console.WriteLine("\nEnter Employee ID of the record to be deleted: ");
            empid = Console.ReadLine();

            string sqlQuery = "execute tempdb.dbo.Delete_Emp " + "'" + empid + "'" + ";";
            int rowAffected = 0;
            SqlCommand command = new SqlCommand(sqlQuery, con);
            rowAffected = command.ExecuteNonQuery();

            if (rowAffected != 0)
            {
                Console.WriteLine("\nData Deleted Successfully\n");
            }
            else
            {
                Console.WriteLine("\nData Deletion Failed\n");
            }

        }


        //Calls the stored procedure Emp_Dept to display the join of Employee and Dept table
        public void Emp_Dept()
        {
            string sqlQuery = "execute tempdb.dbo.Emp_Dept;";
            ad = new SqlDataAdapter(sqlQuery, con);
            ds = new DataSet();
            ad.Fill(ds);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Employee ID: " + ds.Tables[0].Rows[i]["id"] + " Employee Name:" + ds.Tables[0].Rows[i]["ename"] + "  Department Name: " + ds.Tables[0].Rows[i]["dname"]);
                }
            }
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            SQLQueries obj = new SQLQueries();
            Console.WriteLine("\nJoin of Employee Table and Dept Table\n");
            obj.Emp_Dept();
            Console.WriteLine("\nEmployee Table\n");

            obj.Display_Emp();
            obj.Del_Employee();
             Console.WriteLine("\nEmployee Table\n");
            obj.Display_Emp();

            Console.WriteLine("Department Table\n");

            obj.Display_Dept();
            obj.Insert_Dept();

            Console.WriteLine("\nDepartment Table\n");

            obj.Display_Dept();

         

        }
    }
}
