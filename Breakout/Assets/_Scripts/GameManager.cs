﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
   private static GameManager _instance;
   
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };

   public GameState gameState { get; private set; }
   public int vidas;
   public int pontos;
   
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;


   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }
   private GameManager()
   {
       vidas = 3;
       pontos = 0;
       gameState = GameState.MENU;

   }

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME && gameState == GameState.MENU ) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 3;
        pontos = 0;
    }
}