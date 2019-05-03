﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveScorePopUp : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField input;

    

    private void Start() {
        scoreText.SetText(ScoreSystem.Instance.Score.ToString());
        input.Select();
    }
    void SaveScore()
    {
        int score = int.Parse(scoreText.text);
        string name = input.text;

        Leaderboard.AddScore(name, score);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return) && input.text.Length > 0){
            SaveScore();
            GetComponent<Animator>().SetTrigger("out");
        }
    }




}
