using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnviromentInstaller : MonoInstaller
{
    [SerializeField] private ObstaclesSpawner _obstaclesSpawner;
    
    public override void InstallBindings()
    {
        BindObstaclesSpawner();
    }

    private void BindObstaclesSpawner()
    {
        Container.Bind<ObstaclesSpawner>().AsSingle();
    }
}
