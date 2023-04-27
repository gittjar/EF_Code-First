using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class RecordCollectionContext : DbContext
{
    public DbSet<Record> Record { get; set; }
    public DbSet<ProductCompany> Producter { get; set; }

    public string DbPath { get; }

    public RecordCollectionContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "record-database.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    //
    //          /username/.local/share
    //

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}

public class Record
{
    public int ID { get; set; }
    public string? Artist { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public string? ExtraInformation { get; set; }
    public int? Year { get; set; }
    public virtual ProductCompany? ProductCompany { get; set; }
}

// This is record label
public class ProductCompany
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Record>? Records { get; set; }
}
