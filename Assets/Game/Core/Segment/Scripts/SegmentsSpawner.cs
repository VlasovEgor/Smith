using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SegmentsSpawner : MonoBehaviour, IInitializable , IDisposable
{
    [SerializeField] private List<GameObject> _segmentsList;

    [Space]
    [SerializeField] private float _timeBetweenSpawns;

    private SpeedObjects _speedObjects;

    private float _currentTime;
    
    private bool _gameStarted;
    private LevelManager _levelManager;

    [Inject]
    private void Construct(SpeedObjects speedObjects, LevelManager levelManager)
    {
        _speedObjects = speedObjects;
        _levelManager = levelManager;
    }
    
    public void Initialize()
    {
        _levelManager.GameStarted += StartGame;
    }

    public void Dispose()
    {
        _levelManager.GameStarted -= StartGame;
    }

    private void StartGame()
    {
        _gameStarted = true;
    }
    
    private void Update()
    {
        if (!_gameStarted)
        {
            return;
        }
        
        UpdateSpawnTimer();
    }

    private void UpdateSpawnTimer()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeBetweenSpawns)
        {
            SpawnObstacle();
            _currentTime = 0;
        }
    }

    private void SpawnObstacle()
    {   
        int randomSegmentIndex = Random.Range(0, _segmentsList.Count - 1);
        
        var obstaclePrefabs = _segmentsList[randomSegmentIndex];
        
        var obstacle =  Instantiate(obstaclePrefabs, transform.position, Quaternion.identity, transform);

        IMovable movable = obstacle.GetComponent<IMovable>();
        movable.SetSpeed(_speedObjects.Speed);
    }

   
}
