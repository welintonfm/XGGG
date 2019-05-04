using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] int value = 0;


    [ContextMenu("GainScore")]
    public void GainScore()
    {
        ScoreSystem.GainScore(value);
    }
    [ContextMenu("LoseScore")]
    public void LoseScore()
    {
        ScoreSystem.LoseScore(value);
    }

}
