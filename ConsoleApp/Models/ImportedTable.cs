namespace ConsoleApp
{
    using System.Collections.Generic;
    using System.Linq;

    public class ImportedTable : ImportedObjectBaseClass
    {
        public string Schema { get; set; }
        public List<ImportedColumn> Columns { get; set; }
        public override string ToString()
        {
            return $"\tTable '{Schema}.{Name}' ({Columns.Count} columns) \n {string.Join("\n", Columns.Select(x => x.ToString()))}";
        }
    }
    public class TableMapper : IObjectMapper
    {
        public ImportedObjectBaseClass MapPartsToObject(string[] parts)
        {
            return new ImportedTable
            {
                Name = parts[1],
                Schema = parts[2],
                ParentName = parts[3],
                Columns = new List<ImportedColumn>()
            };
        }
    }
}
