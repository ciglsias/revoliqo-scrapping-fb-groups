using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadingAnuncios
{
    public class AnuncioManual
    {
        public string Telefono { get; set; }

        public string Texto { get; set; }

        public string Titulo { get; set; }

        public int Seccion { get; set; }

        public int Categoria { get; set; }

        public static AnuncioManual[] Load(string filepath)
        {
            var jsonString = File.ReadAllText(filepath);

            return System.Text.Json.JsonSerializer.Deserialize<Entrada>(jsonString).Anuncios;
        }
    }

    class Entrada
    {
        public AnuncioManual[] Anuncios { get; set; }
    }
}
