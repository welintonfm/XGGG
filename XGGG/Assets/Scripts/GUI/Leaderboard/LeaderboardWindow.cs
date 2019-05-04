using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LeaderboardWindow : MonoBehaviour
{
    [Header("Leaderboard")]
    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] numbers;

    // [Header("Submit Score System")]

    private void Start()
    {
        Leaderboard.OnLeaderboardChange += UpdateLeaderboard;
        UpdateLeaderboard();
    }
    private void OnDestroy() {
        Leaderboard.OnLeaderboardChange -= UpdateLeaderboard;
    }

    void UpdateLeaderboard()
    {
        List<Score> scores = Leaderboard.Scores;
        for (int i = 0; i < names.Length; i++)
        {
            if (i < scores.Count)
            {
                names[i].SetText(scores[i].name);
                numbers[i].SetText(scores[i].value.ToString());
            }
            else
            {
                names[i].SetText("---");
                numbers[i].SetText("0");
            }
        }
    }

}
