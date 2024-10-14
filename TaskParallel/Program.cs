using System;
using System.IO;
namespace TaskParallel;
class Program
{
    static void Main(string[] args)
    {

        //get full TextFiles subdirectory path
        var textFileFolderPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\");

        //get paths of all *.txt files in that directory
        var filePaths = Directory.GetFiles(textFileFolderPath, "*.txt");

        //run conversions in parallel
        foreach (var filepath in filePaths)
        {
            PdfTool.TextFileToPdf(filepath);
        }
    }
}































































//static void Main(string[] args)
//{

//    //get full TextFiles subdirectory path
//    var textFileFolderPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\");

//    //get paths of all *.txt files in that directory
//    var filePaths = Directory.GetFiles(textFileFolderPath, "*.txt");

//    //note the starting time
//    var begin = DateTime.Now;

//    //run conversions in parallel
//    Parallel.ForEach(filePaths, (filepath) => PdfTool.TextFileToPdf(filepath));

//    //calculate and show time taken
//    Console.WriteLine($"Conversion took  {(DateTime.Now - begin).TotalSeconds} seconds");
//}