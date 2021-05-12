using System;
using System.Linq;
using RevApi.Models;

namespace UploadingAnuncios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Uploading");

            var inputFile = @"D:\Projects\xRevolico\Scrapping Anuncios from FB\Mayo 12\Output\output2.txt";

            var anuncios = AnuncioManual.Load(inputFile);

            var context = new RevContext();

            var count = 0;

            foreach (var anuncioManual in anuncios)
            {
                if (anuncioManual.Categoria > 10000 || string.IsNullOrEmpty(anuncioManual.Titulo))
                {
                    continue;
                }

                count++;

                var now = DateTime.Now;

                var anuncioCMG = new AnuncioCMG()
                {
                    Titulo = anuncioManual.Titulo,
                    Descripcion = anuncioManual.Texto,
                    Telefono = anuncioManual.Telefono,
                    Seccion = anuncioManual.Categoria / 100,
                    Categoria = anuncioManual.Categoria,
                    Precio = 0,
                    Creado = now,
                    ModificadoPorUltimaVez = now,
                    Visitas = 1,
                };

                context.AnunciosCMG.Add(anuncioCMG);
            }

            context.SaveChanges();

            Console.WriteLine($"Done. Agregados: {count}");
        }
    }
}
