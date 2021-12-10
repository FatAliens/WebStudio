using System.Collections;
using SQLite4Unity3d;

public class User
{
    [AutoIncrement, PrimaryKey, Unique]
    public int Id { get; set; }
    [MaxLength(300)]
    public string Name { get; set; }
    [MaxLength(250), Unique]
    public string Email { get; set; }
}