using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;
using UnityAtoms.BaseAtoms;

public class SqliteTest : MonoBehaviour
{
    [SerializeField]
    private StringConstant _dbName;
    [SerializeField]
    private StringReference _userName;
    [SerializeField]
    private StringReference _userEmail;

    private SQLiteConnection _connection;
    private void Awake()
    {
        _connection = new SQLiteConnection(_dbName.Value);
        _connection.CreateTable<User>();
    }

    public void SaveUser()
    {
        _connection.Insert(new User
        {
            Name = _userName.Value,
            Email = _userEmail.Value
        });
    }

    public void LogUsers()
    {
        var users = _connection.Table<User>().ToList();
        foreach (var user in users)
        {
            Debug.Log($"#{user.Id} {user.Name}\n{user.Email}");
        }
    }
}
