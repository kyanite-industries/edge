using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound;
    public bool alreadyPlayed = false;
    [SerializeField] public bool repeatable = false;

    //[SerializeField] private Text subtitleTextUI;
    //[SerializeField] private string subtitleText;

    private float timer2;


    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed)
        {
            if (!repeatable)
            {
                playSound.Play();
                alreadyPlayed = true;
            }
            else if (repeatable)
            {
                playSound.Play();
                alreadyPlayed = false;
            }
        }
        
    }
    
}
