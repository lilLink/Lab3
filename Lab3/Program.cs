using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine("Daily Buglees", Frequency.Monthly, new DateTime(2010, 12, 12), 250000);

            magazine.AddArticles(new Article(new Person("Nick", "Back", new DateTime(1990, 10, 20)),
                "Corona-Time", 2.2));
            magazine.AddEditors(new Person("Kek", "lol", new DateTime(1988, 8, 7)));

            MagazineCollection collection = new MagazineCollection();
            collection.AddDefaults();
            collection.AddMagazines(magazine);
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by mane: ");
            collection.SortByName();
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by releaseDate:");
            collection.SortByDate();
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by copiesCount:");
            collection.SortByDate();
            Console.WriteLine(collection.ToString());

            Console.WriteLine($"Max avg rate: {collection.MaxAvgRate}");
            Console.WriteLine("Magazines with monthly frequency: ");
            Console.WriteLine(String.Join(",", collection.MonthlyMagazines.Select(magazineGroup => magazineGroup.ToString()).ToArray()));

            Console.WriteLine(collection.RatingGroup(2));

            TestCollection testCollection = new TestCollection(2000);
            testCollection.MeasureTime();

        }
    }
}
