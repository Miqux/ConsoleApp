using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new DataReader();
            var mapper = new Mapper();

            var lines = reader.ImportData("data.csv");
            var list = mapper.MapObjectListToDatabaseList(mapper.MapListLineToListObject(lines));
            foreach (var database in list) { Console.WriteLine(database); }
            Console.ReadLine();
        }
    }
}
