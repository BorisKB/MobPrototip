using System;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public Action onStartNewGame;
    public Action onOpenMenuPanel;
    public Action onResume;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject losePanel;
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
        OpenbackGroundMenuPanel();
        menuPanel.SetActive(true);
    }

    public void OpenLosePanel()
    {
        OpenbackGroundMenuPanel();
        losePanel.SetActive(true);
    }

    public void OpenbackGroundMenuPanel()
    {
        backGroundMenuPanel.SetActive(true);
    }

    public void CloseLosePanel()
    {
        ClosebackGroundMenuPanel();
        losePanel.SetActive(false);
    }

    public void ClosebackGroundMenuPanel()
    {
        backGroundMenuPanel.SetActive(false);
    }

    public void CloseMenuPanel() 
    {
        menuPanel.SetActive(false);
        ClosebackGroundMenuPanel();
    }

    public void CloseAllPanel() 
    {
        CloseLosePanel();
        CloseMenuPanel();
        ClosebackGroundMenuPanel();
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
