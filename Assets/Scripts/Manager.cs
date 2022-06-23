﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private CylinderManager _cylinderControl;
    [SerializeField] private PlayerControl player;
    [SerializeField] private PlatformRotate control;
    [SerializeField] private ColorGenerator createNewColors;
    [SerializeField] private UIScore uiScore;
    [SerializeField] private UIMenu uiManager;


    void Start()
    {

        player.onEnterRightBlock += OnHitCurrentBlock;
        player.onGameOver += OpenMenu;
        uiManager.onStartNewGame += NewGame;
        uiManager.onOpenMenuPanel += OpenMenu;
        uiManager.onResume += UnPause;

        _cylinderControl.SetRightBlocks();
    }

    private void OnDestroy() 
    {
        uiManager.onStartNewGame -= NewGame;
        player.onGameOver -= OpenMenu;
        player.onEnterRightBlock -= OnHitCurrentBlock;
        uiManager.onOpenMenuPanel -= OpenMenu;
        uiManager.onResume -= UnPause;
    }

    private void OnHitCurrentBlock() 
    {
        _cylinderControl.SetAllBlockToDefault();
        _cylinderControl.SetRightBlocks();

        createNewColors.GenerateNewColors();
        uiScore.SetScore();

        control.RightButton();
        control.RightButton();
        control.RightButton();
    }

    private void NewGame() 
    {
        uiScore.SetNewScore();
        player.StartPlayer();
        uiManager.CloseMenuPanel();
    }

    private void OpenMenu() 
    {
        uiManager.OpenMenuPanel();
        player.FreezePlayer();
    }

    private void UnPause() 
    {
        uiManager.CloseMenuPanel();
        player.UnFreezePlayer();
    }
}
