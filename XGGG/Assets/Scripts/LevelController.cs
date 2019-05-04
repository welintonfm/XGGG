using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class LevelController : MonoBehaviour
{
    public UnityEvent OnStartGame;
    public UnityEvent OnEndGame;
    static LevelController _instance;

    static LevelController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelController>();
                if (_instance == null)
                {
                    throw new Exception("Cannot find LevelController instance.");
                }
            }
            return _instance;
        }
    }

    public bool GameRunnig;

    void Start()
    {
        SetupLevel();
    }

    void SetupLevel(){
        SolarSystemGenerator.Instance.GenerateLevel();
        GunController.Instance.Setup();
    }

    public void StartGame(){
        GameRunnig = true;
        if(OnStartGame!=null){
            OnStartGame.Invoke();
        }
    }

    [ContextMenu("End Game")]
    public void EndGame(){
        GameRunnig = false;
        if(OnEndGame!=null){
            OnEndGame.Invoke();
        }
    }
}
