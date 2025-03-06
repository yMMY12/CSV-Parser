using CSV_Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSV_Parser.ImportHelpers
{
    public partial class ImportHelper
    {
        public static char DetectDelimiter(string headerLine)
        {
            return headerLine.Contains(';') ? ';' : ',';
        }

        public static int CountColumns(string headerLine, char delimiter)
        {
            return ParseCsvLine(headerLine, delimiter).Length;
        }

        public static string[] ParseCsvLine(string line, char delimiter)
        {
            var pattern = $"(?:^\"|{delimiter}\")((?:[^\"\\\\]|\\\\\"|\"\")*?|[\\w\\W]*?)(?=\"{delimiter}|\"$)|(?:^(?!\")|{delimiter}(?!\"))([^{delimiter}]*?)(?=$|{delimiter})";
            var matches = Regex.Matches(line, pattern);
            return matches.Select(m => m.Value.Trim('\"').Replace("\"\"", "\"")).ToArray();
        }

        public static string CorrectErrors(string line, char delimiter)
        {
            line = line.Replace("\\\",", "\\\" ,").Replace("\\\";", "\\\" ;");

            string[] fields = ParseCsvLine(line, delimiter);

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == null) fields[i] = "";
            }

            return string.Join(delimiter, fields.Select(f => f.Contains(delimiter) ? $"\"{f}\"" : f));
        }

        public static string NormalizeStyledCharacters(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
                return field;

            string normalizedFieldtKD = field.Normalize(NormalizationForm.FormKC);
            string cleanField = RemoveEmojisAndSymbols(normalizedFieldtKD).Replace(" ️", "");
            cleanField = MultiSpaceEliminatorRegex().Replace(cleanField, " ");

            return cleanField;
        }

        private static string RemoveEmojisAndSymbols(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Regex pentru caractere non-ASCII și simboluri Unicode speciale
            return AllLanguageCharsRegex().Replace(input, "");
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex MultiSpaceEliminatorRegex();
        
        [GeneratedRegex(@"[^\p{L}\p{N}\p{M}\s]")]
        private static partial Regex AllLanguageCharsRegex();
    }
}
