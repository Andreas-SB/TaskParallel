using System;
using System.IO;
namespace TaskParallel;
class Program
{
    static void Main(string[] args)
    {
        ConvertTextFilesToPdf();
    }

    private static void ConvertTextFilesToPdf()
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