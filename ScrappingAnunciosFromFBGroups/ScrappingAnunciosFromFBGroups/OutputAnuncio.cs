using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrappingAnunciosFromFBGroups
{
    //classes purposes: just add this field to allow manual data entering later in the same .txt
    public class OutputAnuncio : ParsedAnuncio
    {
        public string Titulo { get; set; }

        public int Seccion { get; set; }

        public int Categoria { get; set; }

        public OutputAnuncio()
        {
            Titulo = "";

            Seccion = 99999999;

            Categoria = 999999999;
        }

        public static void Output(List<ParsedAnuncio> parsedAnuncios, string filepath)
        {
            var list = parsedAnuncios.Select(parsedAnuncio => new OutputAnuncio() {
                Telefono = parsedAnuncio.Telefono,
                Texto = parsedAnuncio.Texto,
            }).ToList();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(new { Anuncios = list}, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filepath, jsonString);
        }
    }
}
