using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class DataReader
    {
        public List<string> ImportData(string fileToImport)
        {
            var streamReader = new StreamReader(fileToImport);

            var importedLines = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                importedLines.Add(line);
            }

            return importedLines;
        }
    }
}
