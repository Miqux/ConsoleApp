using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Mapper
    {
        private Dictionary<string, IObjectMapper> _mappers;

        public Mapper()
        {
            _mappers = new Dictionary<string, IObjectMapper>
            {
                { "table", new TableMapper() },
                { "database", new DatabaseMapper() },
                { "column", new ColumnMapper() }
            };
        }

        private ImportedObjectBaseClass MapLineToObject(string line)
        {
            var parts = line.Split(';');

            //handling of invalid data, to be agreed with business requirements
            if (parts.Count() != 7)
                return null;

            string type = parts[0].ToLower();
            if (_mappers.TryGetValue(type, out var mapper))
            {
                return mapper.MapPartsToObject(parts);
            }
            return null;
        }
        public List<ImportedObjectBaseClass> MapListLineToListObject(List<string> lines, bool haveHeader = true)
        {
            if (haveHeader)
                lines.RemoveAt(0);

            List<ImportedObjectBaseClass> importedObjectBaseClasses = new List<ImportedObjectBaseClass>();

            foreach (var item in lines)
            {
                var mappedObject = MapLineToObject(item);
                if (mappedObject is null)
                    continue;

                importedObjectBaseClasses.Add(mappedObject);
            }

            return importedObjectBaseClasses;
        }
        public List<ImportedDatabase> MapObjectListToDatabaseList(List<ImportedObjectBaseClass> importedObjects)
        {
            var databases = importedObjects.OfType<ImportedDatabase>().ToList();

            foreach (var database in databases)
            {
                database.Tables.AddRange(
                    importedObjects.OfType<ImportedTable>()
                    .Where(table => table.ParentName == database.Name)
                    .Select(table =>
                    {
                        table.Columns.AddRange(importedObjects.OfType<ImportedColumn>()
                            .Where(column => column.ParentName == table.Name));
                        return table;
                    }));
            }

            return databases;
        }
    }
}
