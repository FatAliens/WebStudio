using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique, MaxLength(300)]
    public string Title { get; set; }
    [MaxLength(4000)]
    public string Description { get; set; }
}