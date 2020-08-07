using System;
using System.IO;

namespace FileIO
{
	class BinaryIO
	{
		string opath;
		string npath;
		//Constructor
		public BinaryIO()
        {
			opath = "C:\\Users\\Stuti\\Downloads\\Sample.bin";
			npath = "C:\\Users\\Stuti\\Downloads\\newfile.txt";
			if (File.Exists(npath))
				File.Delete(npath);

		}
		public void BinFunc()
        {
			try
			{
				using (FileStream file = File.OpenRead(opath))
				{
					byte[] data = new byte[file.Length];
					file.Read(data, 0, (int)file.Length);
					file.Close();
					using (StreamWriter nfile = new StreamWriter(npath))
					{
						for (int i = 0; i < data.Length; i++)
						{
							if ((Convert.ToInt32(data[i]) >= 32 && Convert.ToInt32(data[i]) <= 127) || Convert.ToInt32(data[i]) == 10 || Convert.ToInt32(data[i]) == 13)
							{
								nfile.Write(Convert.ToChar(data[i]));
							}
						}
						nfile.Close();
						Console.WriteLine("-----New File--------");
						string text = File.ReadAllText(npath);
						Console.WriteLine(text);
					}


				}
			}
			catch(Exception e)
            {
				Console.WriteLine(e.Message);
            }
		}
	}
}
