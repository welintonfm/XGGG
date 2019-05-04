using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField]int _score;

    public int Score
    {
        get
        {
            return _score;
        }
    }


    static ScoreSystem _instance;

    public static ScoreSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreSystem>();
                if (_instance == null)
                {
                    throw new Exception("Cannot find GunController instance.");
                }
            }
            return _instance;
        }
    }

    [SerializeField] private float rate = 1;

    float nextTime;
    void Start()
    {
        nextTime = Time.time + rate;
        _score = 0;
    }

    void Update()
    {
        if (nextTime < Time.time)
        {
            _score += 1;
            nextTime = Time.time + rate;
        }
    }

    public static void GainScore(int value){
        Instance._score += value;
    }

    public static void LoseScore(int value){
        Instance._score -= value;
    }
}
