using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<GameObject> _obstaclesList;

    [Space]
    [SerializeField] private float _timeBetweenSpawns;

    private SpeedObjects _speedObjects;

    private float _currentTime;

    [Inject]
    private void Construct(SpeedObjects speedObjects)
    {
        _speedObjects = speedObjects;
        Debug.Log("ABOBA: " + speedObjects.Speed);
    }
    
    private void Update()
    {
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
        int randomObstacleIndex = Random.Range(0, _obstaclesList.Count - 1);
        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Count - 1);
        
        var obstaclePrefabs = _obstaclesList[randomObstacleIndex];
        var spawnPosition = _spawnPoints[randomSpawnPointIndex].position;
        
        var obstacle =  Instantiate(obstaclePrefabs, spawnPosition, Quaternion.identity, transform);

        IMovable movable = obstacle.GetComponent<IMovable>();
        movable.SetSpeed(_speedObjects.Speed);
    }
}
