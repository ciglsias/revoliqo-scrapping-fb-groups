using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScrappingAnunciosFromFBGroups
{
    public class Parser
    {
        public static List<ParsedAnuncio> Parse(string filepath)
        {
            var text = File.ReadAllText(filepath);

            var rx = new Regex(@"^.*(5\d{7}).*$", RegexOptions.Multiline);

            var matches = rx.Matches(text);

            var result = new List<ParsedAnuncio>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var full = groups[0].Value;

                var telefono = groups[1].Value;

                var texto = full;

                if (texto.Length > 300 || texto.Contains("<") || texto.Contains(">"))
                {
                    continue;
                }

                if (texto.EndsWith("\r"))
                {
                    texto = texto.Substring(0, texto.Length - 1);
                }

                var parsedAnuncio = new ParsedAnuncio()
                {
                    Telefono = telefono,
                    Texto = texto,
                };

                result.Add(parsedAnuncio);
            }

            return result;
        }

    }
}
