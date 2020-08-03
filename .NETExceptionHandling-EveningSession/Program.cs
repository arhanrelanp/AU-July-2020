using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Net_ExceptionHandling
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Boolean flag = true;
            log.Info("Program started executing");

            string path ="C:\\Users\\Stuti\\Documents\\Sample.txt";
            try
            {
                string output = File.ReadAllText(path);
                Console.WriteLine("\n--File--\n");
                Console.WriteLine(output);
                Console.WriteLine("\n---------");

            }
            catch(FileLoadException e)
            {
                flag = false;
                Console.WriteLine("\nUnable to load the file\n");
                log.Error(e.StackTrace);
            }
            catch (DirectoryNotFoundException e)
            {
                flag = false;
                Console.WriteLine("\nDirectory Not Found\n");
                log.Error(e.StackTrace);
            }
            catch(FileNotFoundException e)
            {
                flag = false;
                Console.WriteLine("\nFile Not Found\n");
                log.Error(e.StackTrace);
            }
            catch (IOException e)
            {
                flag = false;
                Console.WriteLine("\nAn Input Output Error\n");
                log.Error(e.StackTrace);
            }
            catch(Exception e)
            {
                flag = false;
                Console.WriteLine("\nAn Unexpected Error occured\n");
                log.Fatal(e.StackTrace);
            }
            finally
            {
                if(flag)
                {
                    log.Info("File Read Successfully");
                }
                else
                {
                    log.Warn("\nFile Read Unsuccessful");
                }
                log.Info("Program Execution Ended\n\n");
        }
        
    }
}
