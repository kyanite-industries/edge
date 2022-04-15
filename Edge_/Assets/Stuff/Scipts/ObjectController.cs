using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectController : MonoBehaviour
{
    [SerializeField] private string objectName;

    [TextArea] [SerializeField] private string extraInfo;

    [SerializeField] private InspectController inspectController;

    public AudioSource playIntSound;
    public bool alreadyIntPlayed = false;

    public void ShowObjectName()
    {
        inspectController.showname(objectName);
    }
    public void hideObjectName()
    {
        inspectController.hidename();
    }
    public void ShowExtraInfo()
    {
        inspectController.showAdditionalInfo(extraInfo);
        
    }
    public void doPlayIntSound()
    {
        playIntSound.Play();
        alreadyIntPlayed = true;
    }
}
