using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioManager audioManager;
    public void Play(string clipname)
    {
        if(audioManager== null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        
        audioManager.PlaySound(clipname);
        Debug.Log("tocou sonzinho:  teixe, morri");
        return;
    }
}
