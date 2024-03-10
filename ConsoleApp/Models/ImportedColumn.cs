namespace ConsoleApp
{
    public class ImportedColumn : ImportedObjectBaseClass
    {
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public override string ToString()
        {
            return $"\t\tColumn '{Name}' with {DataType} data type {(IsNullable ? "accepts nulls" : "with no nulls")}";
        }
    }
    public class ColumnMapper : IObjectMapper
    {
        public ImportedObjectBaseClass MapPartsToObject(string[] parts)
        {
            return new ImportedColumn
            {
                Name = parts[1],
                DataType = parts[5],
                IsNullable = parts[6] == "1" ? true : false,
                ParentName = parts[3]
            };
        }
    }
}
