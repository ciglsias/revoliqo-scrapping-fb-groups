using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrappingAnunciosFromFBGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            //var inputFilePath = @"C:\Users\Carlos\Desktop\Scraping FB Groups\Saving Page\(16) Todo en camaguey _ Grupos _ Facebook.html";
            var inputFilePath = @"C:\Users\Carlos\Desktop\Scraping FB Groups\SelectAllCopyPaste\text.txt";
            
            var anunciosParsed = Parser.Parse(inputFilePath);

            var outputFilePath = "output.txt";

            OutputAnuncio.Output(anunciosParsed, outputFilePath);
        }
    }
}
