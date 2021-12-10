using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Project
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique, MaxLength(300)]
    public string Title { get; set; }
    [MaxLength(4000)]
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public bool IsCompleted { get; set; }
    public int CustomerForeingKey { get; set; }
    
}