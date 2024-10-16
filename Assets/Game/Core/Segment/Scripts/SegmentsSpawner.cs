using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SegmentsSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _segmentsList;

    [Space]
    [SerializeField] private float _timeBetweenSpawns;

    private SpeedObjects _speedObjects;

    private float _currentTime;

    [Inject]
    private void Construct(SpeedObjects speedObjects)
    {
        _speedObjects = speedObjects;
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
        int randomSegmentIndex = Random.Range(0, _segmentsList.Count - 1);
        
        var obstaclePrefabs = _segmentsList[randomSegmentIndex];
        
        var obstacle =  Instantiate(obstaclePrefabs, transform.position, Quaternion.identity, transform);

        IMovable movable = obstacle.GetComponent<IMovable>();
        movable.SetSpeed(_speedObjects.Speed);
    }
}
