
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIHealth _uiHealth;
    [SerializeField] private UIScore _uiScore;
    
    public override void InstallBindings()
    {
        BindHealth();
        BindScore();
    }

    private void BindHealth()
    {
        Container.BindInterfacesAndSelfTo<UIHealth>().FromInstance(_uiHealth).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<UIScore>().FromInstance(_uiScore).AsSingle();
    }
}
