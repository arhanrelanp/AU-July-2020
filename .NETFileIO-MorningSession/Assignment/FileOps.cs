using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileIO
{
	class FileOps
	{
		string path;		//path of the original file
		string path_rev;	//path of the new file with reversed contents
		public FileOps()
        {
			string dir_name;
			Console.WriteLine("Enter name of the directory");
			dir_name = Console.ReadLine();
			if (!Directory.Exists("C:\\Users\\Stuti\\Desktop\\" + dir_name))
				Directory.CreateDirectory("C:\\Users\\Stuti\\Desktop\\" + dir_name);
            else
            {
				Console.WriteLine("Directory with same name exists!");
            }
			path = "C:\\Users\\Stuti\\Desktop\\" + dir_name + "\\Sample.txt";
			path_rev = "C:\\Users\\Stuti\\Desktop\\" + dir_name + "\\Rev.txt";
			if (File.Exists(path))
				File.Delete(path);

			if (File.Exists(path_rev))
				File.Delete(path_rev);

		}
		//Function to enter text in sample.txt
		private void input()
        {
			int lines;
			string input;
			Console.WriteLine("Enter the number of input lines: ");
			lines = Convert.ToInt32(Console.ReadLine());
			using(StreamWriter file = new StreamWriter(path))
            {
				while(lines>0)
                {
					input = Console.ReadLine();
					file.WriteLine(input);
					lines--;

                }
				file.Close();
            }
        }
		//Function to count the number of words in sample.txt
		private void WordCount()
        {
			int count = 0;
			string textline;
			using(StreamReader file = File.OpenText(path))
            {
				textline = file.ReadLine();
				while (textline!=null)
				{ 
						string[] words = textline.Split(' ');
						count += words.Length;
						textline = file.ReadLine();
				}
				file.Close();
            }
			Console.WriteLine("No of words in the file are: " + count);
        }
		//Function to write the reverse content of sample.txt in another file
		private void RevFile()
        {
			using(StreamReader file = File.OpenText(path))
            {
				using(StreamWriter rev_file= new StreamWriter(path_rev))
                {
					string rtext, wtext;
					Stack<string> stack = new Stack<string>();			//using stack as it operates in LIFO manner and reverse content is copied
					while((rtext=file.ReadLine())!=null)
                    {
						stack.Push(rtext);
                    }
					while(stack.Count!=0)
                    {
						wtext = stack.Pop();
						rev_file.WriteLine(wtext);
                    }
					rev_file.Close();
					file.Close();

                }
            }
        }
		public void callops()
        {
			//This functions allows the manipulations to be called only by this function and not individually
			input();
			WordCount();
			RevFile();

        }
	}
}
