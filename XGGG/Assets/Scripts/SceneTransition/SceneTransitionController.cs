using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneTransitionController : MonoBehaviour
{
    private string sceneName;
    public void ChangeSceneWithTransition(string name){
        sceneName = name;
        GetComponent<Animator>().SetTrigger("fadeIn");
    }
    public void ChangeScene(){
        SceneManager.LoadScene(sceneName);
    }
}
