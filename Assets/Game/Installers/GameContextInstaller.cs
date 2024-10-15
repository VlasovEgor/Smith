using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{   
    [SerializeField] private SpeedObjects _speedObjects;
    
    public override void InstallBindings()
    {
        BindSpeedObjects();
    }

    private void BindSpeedObjects()
    {
        Container.Bind<SpeedObjects>().FromInstance(_speedObjects).AsSingle();
    }
}
