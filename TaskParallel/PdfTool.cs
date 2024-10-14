using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TaskParallel
{
    public static class PdfTool
    {
        private const int MS_DELAY = 250;
        public  static void TextFileToPdf(string sourceTextFilePath, string outputPdfFilePath = null)
        {
            Console.WriteLine($"Converting {sourceTextFilePath} to pdf...");
            Task.Delay(MS_DELAY).Wait();

            outputPdfFilePath = outputPdfFilePath ?? GetOutputPathFromSourcePath(sourceTextFilePath);

            try
            {
                string inputText = File.ReadAllText(sourceTextFilePath);
                Document document = new Document(new PdfDocument(new PdfWriter(outputPdfFilePath)));
                document.Add(new Paragraph(inputText));
                document.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error trying to convert '{sourceTextFilePath}' to PDF file: '{outputPdfFilePath}'. Error was '{ex}'", ex);
            }
        }

        private static string GetOutputPathFromSourcePath(string sourceTextFilePath)
        {
            var filePathWithoutExt = Path.GetFileNameWithoutExtension(sourceTextFilePath);
            var outputFolderPath = Path.GetDirectoryName(sourceTextFilePath);
            var outputPdfFileName = filePathWithoutExt + ".pdf";
            return  Path.Combine(outputFolderPath, outputPdfFileName);
        }
    }
}