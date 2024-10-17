using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public event Action LevelOpened;
    
    [SerializeField] private StartButton _startButton;
    [SerializeField] private GameObject _gameUI;

    private void Start()
    {
        _startButton.AddListener(OpenLevel);
    }

    private void OnDestroy()
    {
        _startButton.RemoveListener(OpenLevel);
    }

    private void OpenLevel()
    {
        gameObject.SetActive(false);
        _gameUI.SetActive(true);
        
        LevelOpened?.Invoke();
    }
}
