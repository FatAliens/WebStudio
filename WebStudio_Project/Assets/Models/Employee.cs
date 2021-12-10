using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique, MaxLength(300)]
    public string Name { get; set; }
    [MaxLength(4000)]
    public string Post { get; set; }
}