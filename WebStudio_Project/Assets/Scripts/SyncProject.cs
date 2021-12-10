using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class SyncProject : MonoBehaviour
{
    [SerializeField]
    private StringConstant _dbName;

    [SerializeField] private IntReference _id;
    [SerializeField] private StringReference _title;
    [SerializeField] private StringReference _description;
    [SerializeField] private StringReference _startDate;
    [SerializeField] private StringReference _endDate;
    [SerializeField] private BoolReference _cheched;
    public Project Project { get; set; }

    private SQLiteConnection _connection;

    private void Awake()
    {
        _connection = new SQLiteConnection(_dbName.Value);
    }
    public void Load()
    {
        _id.Value = Project.Id;
        _title.Value = Project.Title;
        _description.Value = Project.Description;
        _startDate.Value = Project.StartDate.ToString("d MMMM yã.");
        _endDate.Value = Project.EndDate.ToString("d MMMM yã.");
        _cheched.Value = Project.IsCompleted;
    }

    public void UpdateData()
    {
        Project.IsCompleted = _cheched.Value;
        _connection.Update(Project);
    }
}
