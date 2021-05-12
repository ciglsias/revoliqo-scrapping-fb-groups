﻿using System;
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
            var inputFilePath = @"D:\Projects\xRevolico\Scrapping Anuncios from FB\Mayo 12\Input\input2.txt";
            
            var anunciosParsed = Parser.Parse(inputFilePath);

            var outputFilePath = @"D:\Projects\xRevolico\Scrapping Anuncios from FB\Mayo 12\Output\output2.txt";

            OutputAnuncio.Output(anunciosParsed, outputFilePath);
        }
    }
}
