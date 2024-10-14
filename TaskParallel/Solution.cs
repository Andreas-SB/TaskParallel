using System;
using System.IO;
using System.Threading.Tasks;
namespace TaskParallel;
class Solution
{
    public static void ConvertTextFilesToPdfInParallel()
    {
        //get full TextFiles subdirectory path
        var textFileFolderPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\");

        //get paths of all *.txt files in that directory
        var filePaths = Directory.GetFiles(textFileFolderPath, "*.txt");

        //note the starting time
        var begin = DateTime.Now;

        //run conversions in parallel
        Parallel.ForEach(filePaths, (filepath) => PdfTool.TextFileToPdf(filepath));

        //calculate and show time taken
        Console.WriteLine($"Conversion took  {(DateTime.Now - begin).TotalSeconds} seconds");
    }
}