namespace ConsoleApp
{
    public interface IObjectMapper
    {
        ImportedObjectBaseClass MapPartsToObject(string[] parts);
    }
}
