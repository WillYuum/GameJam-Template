using System;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public event Action OnGameLoopStart;
    public event Action OnLoseGame;
    public bool LoopIsActive { get; private set; }


    private void Awake()
    {
        enabled = false;
        LoopIsActive = false;
    }


    public void InvokeStartGameLoop()
    {
        enabled = true;
        LoopIsActive = true;

        if (OnGameLoopStart != null)
        {
            OnGameLoopStart();
        }
    }

    public void InvokeLoseGame()
    {
        if (LoopIsActive == false) return;

        enabled = false;
        LoopIsActive = false;

        if (OnLoseGame != null)
        {
            OnLoseGame();
        }
    }
}
