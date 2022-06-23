using System;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public Action onStartNewGame;
    public Action onOpenMenuPanel;
    public Action onResume;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject backGroundMenuPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenuPanel() 
    {
        backGroundMenuPanel.SetActive(true);
        menuPanel.SetActive(true);
    }

    public void CloseMenuPanel() 
    {
        menuPanel.SetActive(false);
        backGroundMenuPanel.SetActive(false);
    }

    public void Menu() 
    {
        onOpenMenuPanel?.Invoke();
    }
    public void NewGame() 
    {
        onStartNewGame?.Invoke();
    }
    public void Resume() 
    {
        onResume?.Invoke();
    }
   
}
