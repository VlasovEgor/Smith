using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class EnviromentInstaller : MonoInstaller
{
    [FormerlySerializedAs("_obstaclesSpawner")] [SerializeField] private SegmentsSpawner segmentsSpawner;
    
    public override void InstallBindings()
    {
        BindObstaclesSpawner();
    }

    private void BindObstaclesSpawner()
    {
        Container.Bind<SegmentsSpawner>().AsSingle();
    }
}
