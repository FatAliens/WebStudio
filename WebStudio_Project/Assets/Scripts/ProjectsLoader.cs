using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;

public class ProjectsLoader : MonoBehaviour
{
    [SerializeField]
    private StringConstant _dbName;
    [SerializeField]
    private GameObject _prefab;

    private SQLiteConnection _connection;
    private List<Project> _projects = new List<Project>();
    private List<Project> _spawnedProjects = new List<Project>();

    private void Awake()
    {
        _connection = new SQLiteConnection(_dbName.Value);
    }

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        LoadProjects();
        DrawProjects();
    }

    private void LoadProjects()
    {
        _projects = _connection.Table<Project>().ToList();
    }

    private void DrawProjects()
    {
        foreach (var project in _projects)
        {
            var instant = GameObject.Instantiate(_prefab, transform);
            var sync = instant.GetComponent<SyncProject>();
            sync.Project = project;
            sync.Load();
            _spawnedProjects.Add(project);
        }
    }
}
