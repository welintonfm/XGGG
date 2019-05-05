using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneTransitionController : MonoBehaviour
{
    public UnityEvent OnSceneLoaded;
    public UnityEvent OnEndFadeIn;
    private string sceneName;

    public void ChangeSceneWithTransition(string name){
        sceneName = name;
        GetComponent<Animator>().SetTrigger("fadeIn");
    }
    public void ChangeScene(){
        SceneManager.LoadScene(sceneName);
    }

    public void EndFadeIn(){
        if(OnEndFadeIn != null){
            OnEndFadeIn.Invoke();
        }
    }

    public void SceneLoaded(){
        if(OnSceneLoaded != null){
            OnSceneLoaded.Invoke();
        }
    }
}
