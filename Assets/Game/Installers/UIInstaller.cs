
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIHealth _uiHealth;
    [SerializeField] private UIScore _uiScore;
    [SerializeField] private Menu _menu;
    
    public override void InstallBindings()
    {
        BindHealth();
        BindScore();
        BindMenu();
    }

    private void BindHealth()
    {
        Container.BindInterfacesAndSelfTo<UIHealth>().FromInstance(_uiHealth).AsSingle();
    }
    
    private void BindScore()
    {
        Container.BindInterfacesAndSelfTo<UIScore>().FromInstance(_uiScore).AsSingle();
    }
    
    private void BindMenu()
    {
        Container.Bind<Menu>().FromInstance(_menu).AsSingle();
    }
}
