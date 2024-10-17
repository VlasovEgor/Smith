using System;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour, IInitializable, IDisposable
{
   public event Action GameStarted;
   
   private Menu _menu;
   private bool _levelIsRunning;
   private bool _screenIsTapped;
   
   [Inject]
   private void Construct(Menu menu)
   {
      _menu = menu;
   }

   public void Initialize()
   {
      _menu.LevelOpened += StartLevel;
   }

   public void Dispose()
   {
      _menu.LevelOpened -= StartLevel;
   }
   
   private void StartLevel()
   {
      _levelIsRunning = true;
   }
   
   private void Update()
   {
      CheckingTapToScreen();
   }
   
   private void CheckingTapToScreen()
   {
      if (!_levelIsRunning)
      {
         return;
      }
      
      if (Input.GetMouseButtonDown(0) && !_screenIsTapped)
      {
         _screenIsTapped = true;
         GameStarted?.Invoke();
      }
   }
}
