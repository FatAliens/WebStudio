using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using YamlDotNet.Serialization;

public class DataSeeder : MonoBehaviour
{
    
    [SerializeField]
    private StringConstant _dbName;

    [SerializeField]
    private TextAsset _projectsYaml;
    [SerializeField]
    private TextAsset _tasksYaml;
    [SerializeField]
    private TextAsset _customersYaml;
    [SerializeField]
    private TextAsset _employeesYaml;

    private SQLiteConnection _connection;

    private void Awake()
    {
        _connection = new SQLiteConnection(_dbName.Value);

        //DropAllTables();
        //CreateAllTables();

        //Seed();
    }

    public void DropAllTables()
    {
        _connection.DropTable<Project>();
        _connection.DropTable<ProjectTask>();
        _connection.DropTable<Customer>();
        _connection.DropTable<Employee>();
    }

    public void CreateAllTables()
    {
        _connection.CreateTable<Project>();
        _connection.CreateTable<ProjectTask>();
        _connection.CreateTable<Customer>();
        _connection.CreateTable<Employee>();
    }

    public void Seed()
    {
        var projects = DeserializeItemsFromYaml<List<Project>>(_projectsYaml.ToString());
        var tasks = DeserializeItemsFromYaml<List<ProjectTask>>(_tasksYaml.ToString());
        var customers = DeserializeItemsFromYaml<List<Customer>>(_customersYaml.ToString());
        var employees = DeserializeItemsFromYaml<List<Employee>>(_employeesYaml.ToString());
        
        _connection.InsertAll(projects);
        _connection.InsertAll(tasks);
        _connection.InsertAll(customers);
        _connection.InsertAll(employees);

        Debug.Log($"Projects count {_connection.Table<Project>().Count()}");
        Debug.Log($"Tasks count {_connection.Table<ProjectTask>().Count()}");
        Debug.Log($"Customers count {_connection.Table<Customer>().Count()}");
        Debug.Log($"Employees count {_connection.Table<Employee>().Count()}");
    }

    public T DeserializeItemsFromYaml<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder().Build();
        return deserializer.Deserialize<T>(yaml);
    }
}
