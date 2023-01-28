using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.EntityFrameworkCore;

using var db = new RecordCollectionContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Your database path: {db.DbPath}.");

Console.WriteLine("Artist name:");
string inputArtist = Console.ReadLine();

Console.WriteLine("Record name:");
string inputTitle = Console.ReadLine();

Console.WriteLine("Genre:");
string inputGenre = Console.ReadLine();

Console.WriteLine("Extra information:");
string inputExtraInfo = Console.ReadLine();

int inputYear;
Console.WriteLine("Publish year:");
string iYear = Console.ReadLine();
inputYear = Convert.ToInt32(iYear);

Console.WriteLine("Label:");
string inputProductCompany = Console.ReadLine();


// Adds a label

var pcompany01 = new ProductCompany
{
    Name = inputProductCompany
};

/* Use this if you want seed database.
 
var pcompany02 = new ProductCompany
{
    Name = "Elektra Records"
};
*/

db.Producter.Add(pcompany01);

// db.Producter.Add(pcompany02);


// Adds some info
db.Record.Add(new Record
{

    Artist = inputArtist,
    Title = inputTitle,
    Genre = inputGenre,
    ExtraInformation = inputExtraInfo,
    Year = inputYear,
    ProductCompany = pcompany01
});

/* Use this if you want seed database.
 
db.Record.Add(new Record
{

    Artist = "Metallica",
    Title = "The Black Album",
    Genre = "Heavy metal",
    ExtraInformation = "Sold over 30 m. record worldwide.",
    Year = 1991,
    ProductCompany = pcompany02
});
*/

// save changes databaseen
db.SaveChanges();

Console.WriteLine("-----");

// Gets and prints all records in database
using (var context = new RecordCollectionContext())
{
    var records = context.Record
      .Include(p => p.ProductCompany);
    foreach (var record in records)
    {
        var data = new StringBuilder();
        data.AppendLine($"Artist: {record.ID}");
        data.AppendLine($"Artist: {record.Artist}");
        data.AppendLine($"Title: {record.Title}");
        data.AppendLine($"Year: {record.Year}");
        data.AppendLine($"Genre: {record.Genre}");
        data.AppendLine($"Label: {record.ProductCompany?.Name}");
        Console.WriteLine(data.ToString());
    }
}

// levyn poisto by ID

Console.WriteLine("Delete record?");
Console.WriteLine("Kirjoita levyn (ID:nro) joka poistetaan, jätä tyhjäksi jos ei poisteta mitään:");

int inputDelete;
string iDelete = Console.ReadLine();
inputDelete = Convert.ToInt32(iDelete);

var deleterecord = new Record() { ID = inputDelete };
db.Record.Attach(deleterecord);
db.Record.Remove(deleterecord);
db.SaveChanges();

Console.WriteLine($"Poistettu onnistuneestu levy ID: {inputDelete}");









