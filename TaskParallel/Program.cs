using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace TaskParallel;
class Program
{
    static DateTime startTime;
    static DateTime endTime;
    static void Main(string[] args)
    {
        //Start time
        startTime = DateTime.Now;

        //Create thread
        Thread TimeThread = new Thread(TimeTracker);
        TimeThread.Start();
        
        //Run converter
        ConvertTextFilesToPdf();

        //End time
        endTime = DateTime.Now;

        //Wait on thread to finish
        TimeThread.Join();

        //Print total time
        Console.WriteLine($"\nTotal time taken: {(endTime - startTime).TotalSeconds:F2} seconds");
    }

    private static void TimeTracker()
    {
        while (endTime == default)
        {
            var elapsed = DateTime.Now - startTime;
            Console.Write($"\rTime elapsed: {elapsed.TotalSeconds:F2} seconds");
            Thread.Sleep(500);
        }
    }

    private static void ConvertTextFilesToPdf()
    {
        //get full TextFiles subdirectory path
        var textFileFolderPath = Path.Combine(Environment.CurrentDirectory, "TextFiles\\");

        //get paths of all *.txt files in that directory
        var filePaths = Directory.GetFiles(textFileFolderPath, "*.txt");

        //run conversions in parallel
        Parallel.ForEach(filePaths, filePath =>
        {
            PdfTool.TextFileToPdf(filePath);
        });
    }
}