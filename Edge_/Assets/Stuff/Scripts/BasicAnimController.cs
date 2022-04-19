using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimController : MonoBehaviour
{

    [SerializeField] private Animator animController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animController.SetBool("isInTrigger", true);
        }
        if (other.CompareTag("MainCamera"))
        {
            animController.SetBool("CamisInTrigger", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animController.SetBool("isInTrigger", false);
        }
        if (other.CompareTag("MainCamera"))
        {
            animController.SetBool("CamisInTrigger", false);
        }
    }
}
