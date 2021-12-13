using System;
using System.IO;
namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Document\n");
           writeDocument();

        }
        static void writeDocument() {
            try 
            {
                Console.WriteLine ("Enter the name of the document");
                string name = Console.ReadLine();
                StreamWriter file = File.AppendText($"{name}.txt");
                string fileName = (name + ".txt");
                Console.WriteLine("Enter the content of the document");
                string fileContent = Console.ReadLine();
                file.WriteLine(fileContent);
                file.Close();

                // read
                StreamReader fileReader = new StreamReader(fileName);
                Console.WriteLine($"{fileName} was successfully saved. The document contains {fileContent.Length} characters.");
            }
            catch (Exception err)
            {
                Console.WriteLine($"Exception: {err.Message}");
            }
            // read
            
        }
    }
}
