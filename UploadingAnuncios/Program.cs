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

            for (int i = 1; i < 12; i++)
            {
                var inputFile = $"D:\\Projects\\xRevolico\\Scrapping Anuncios from FB\\Mayo 10\\Output\\output{i}.txt";

                var anuncios = AnuncioManual.Load(inputFile);

                var context = new RevContext();

                foreach (var anuncioManual in anuncios)
                {
                    if (anuncioManual.Seccion > 10000 || anuncioManual.Categoria > 10000 || string.IsNullOrEmpty(anuncioManual.Titulo))
                    {
                        continue;
                    }

                    var now = DateTime.Now;

                    var anuncioCMG = new AnuncioCMG()
                    {
                        Titulo = anuncioManual.Titulo,
                        Descripcion = anuncioManual.Texto,
                        Telefono = anuncioManual.Telefono,
                        Seccion = anuncioManual.Seccion,
                        Categoria = anuncioManual.Categoria,
                        Precio = 0,
                        Creado = now,
                        ModificadoPorUltimaVez = now,
                        Visitas = 1,
                    };

                    context.AnunciosCMG.Add(anuncioCMG);
                }

                context.SaveChanges();
            }

            Console.WriteLine("Done");
        }
    }
}
