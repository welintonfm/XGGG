using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameUIController : MonoBehaviour
{

    public Canvas canvas;
    public GameObject LeaderboardWindow;
    public GameObject SaveScorePopUp;
    public TextMeshProUGUI scoreNumber;

    public GameObject menu;


    //Gamiarra show
    Animator ssPopUp;
    private void Start()
    {
        // OnGameEnd();
    }

    public void OnGameEnd()
    {
        // Is a Top Score
        if (Leaderboard.Scores.Count == 0 || Leaderboard.Scores.Count < 10 || ScoreSystem.Instance.Score > Leaderboard.Scores[Leaderboard.Scores.Count - 1].value )
        {
            ssPopUp = Instantiate(SaveScorePopUp, Vector3.zero, Quaternion.identity, canvas.transform).GetComponent<Animator>();
        }
        else
        {
            Instantiate(LeaderboardWindow, Vector3.zero, Quaternion.identity, canvas.transform);
            menu.SetActive(true);
        }
    }


    private void Update()
    {
        //Gambiarra show
        //popup sendo exibido
        if (ssPopUp != null)
        {
            if (ssPopUp.GetCurrentAnimatorStateInfo(0).IsName("PopUpOut") &&
                ssPopUp.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Instantiate(LeaderboardWindow, Vector3.zero, Quaternion.identity, canvas.transform);
                Destroy(ssPopUp.gameObject);
                menu.SetActive(true);
                ssPopUp = null;
            }
        }

        scoreNumber.SetText(ScoreSystem.Instance.Score.ToString());


    }


}
