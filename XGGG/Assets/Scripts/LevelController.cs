using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class LevelController : MonoBehaviour
{
    public List<PlanetBehavior> planets;

    public LifeBehaviour star;
    public UnityEvent OnStartGame;
    public UnityEvent OnEndGame;
    static LevelController _instance;

    public static LevelController Instance
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

    private void Update() {
        if(GameRunnig){
            for (int i = 0; i < planets.Count; i++)
            {
                
                if(planets[i].GetComponent<LifeBehaviour>() == null || planets[i].GetComponent<LifeBehaviour>().GetHealth() <= 0){
                    planets.RemoveAt(i);
                }

                if(planets.Count  == 0){
                    EndGame();
                }
            }

            if(star == null || star.GetHealth() == 0){
                EndGame();
            }
        }
    }

    void SetupLevel(){
        SolarSystemGenerator.Instance.GenerateLevel();
        GunController.Instance.Setup();
        this.planets = new List<PlanetBehavior>(FindObjectsOfType<PlanetBehavior>());
        this.star = GameObject.FindGameObjectWithTag("Star").GetComponent<LifeBehaviour>();
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
