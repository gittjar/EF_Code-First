using System;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.Sqlite;

namespace EFCodeFirst
{
    public class Aanite
    {

        public void addRecord()
        {
            using var db = new RecordCollectionContext();

            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Your database path: {db.DbPath}.");

            Console.WriteLine("Artist name:");
            string? inputArtist = Console.ReadLine();

            Console.WriteLine("Record name:");
            string? inputTitle = Console.ReadLine();

            Console.WriteLine("Genre:");
            string? inputGenre = Console.ReadLine();

            Console.WriteLine("Extra information:");
            string? inputExtraInfo = Console.ReadLine();

            int inputYear;
            Console.WriteLine("Publish year:");
            string? iYear = Console.ReadLine();
            inputYear = Convert.ToInt32(iYear);

            Console.WriteLine("Label:");
            string? inputProductCompany = Console.ReadLine();


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
        }

        public void removeRecord()
        {
            // levyn poisto by ID
            using var db = new RecordCollectionContext();


            Console.WriteLine("Delete record?");
            Console.WriteLine("Give record ID for deletion, press enter if not delete.");

            int inputDelete;
            string? iDelete = Console.ReadLine();
            inputDelete = Convert.ToInt32(iDelete);

            var deleterecord = new Record() { ID = inputDelete };
            db.Record.Attach(deleterecord);
            db.Record.Remove(deleterecord);
            db.SaveChanges();

            Console.WriteLine($"Poistettu onnistuneestu levy ID: {inputDelete}");
        }

        public void printAllRecord()
        {
            // Gets and prints all records in database
            using (var context = new RecordCollectionContext())
            {
                var records = context.Record
                  .Include(p => p.ProductCompany);
                foreach (var record in records)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Record-ID: {record.ID}");
                    data.AppendLine($"Artist: {record.Artist}");
                    data.AppendLine($"Title: {record.Title}");
                    data.AppendLine($"Year: {record.Year}");
                    data.AppendLine($"Genre: {record.Genre}");
                    data.AppendLine($"Label: {record.ProductCompany?.Name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

    
            public void searchRecord()
            {
            Console.WriteLine("Give artist name or record title:");
            // Search Artist or Title

            string? userInput = Console.ReadLine();

            using (var context = new RecordCollectionContext())
            {
                var records = context.Record
                .Include(p => p.ProductCompany)
                .Where(r => r.Artist == userInput || r.Title == userInput);

                int i = 0;

                foreach (var record in records)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Record-ID: {record.ID}");
                    data.AppendLine($"Artist: {record.Artist}");
                    data.AppendLine($"Title: {record.Title}");
                    data.AppendLine($"Year: {record.Year}");
                    data.AppendLine($"Genre: {record.Genre}");
                    data.AppendLine($"Label: {record.ProductCompany?.Name}");
                    Console.WriteLine(data.ToString());
                    i++;
                }
                Console.WriteLine("--------");
                Console.WriteLine($"Founded {i} records!");
            }

        }
        }
}



    


