namespace ConsoleApp
{
    using System.Collections.Generic;
    using System.Linq;

    public class ImportedDatabase : ImportedObjectBaseClass
    {
        public List<ImportedTable> Tables { get; set; }
        public override string ToString()
        {
            return $"Database '{Name}' ({Tables.Count()} tables) \n {string.Join("\n", Tables.Select(x => x.ToString()))}";
        }
    }
    public class DatabaseMapper : IObjectMapper
    {
        public ImportedObjectBaseClass MapPartsToObject(string[] parts)
        {
            return new ImportedDatabase
            {
                Name = parts[1],
                ParentName = null,
                Tables = new List<ImportedTable>()
            };
        }
    }
}
