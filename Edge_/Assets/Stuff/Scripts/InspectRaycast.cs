using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private int raylength = 5;
    [SerializeField] private LayerMask LayerMaskInteract;
    private ObjectController raycastedObj;

    [SerializeField] private Image crosshair;
    private bool isCrosshairActive;
    private bool doOnce;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, raylength, LayerMaskInteract.value))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                }
            }
            if (hit.collider.CompareTag("Untagged"))
            {
                raycastedObj.hideObjectName();
            }
            if (hit.collider.CompareTag("DoorButton"))
            {
                return;
            }

            isCrosshairActive = true;
            doOnce = true;

            if (Input.GetMouseButtonDown(1))
            {
                raycastedObj.doPlayIntSound();
                
            }
            else
            {
                return;
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                raycastedObj.hideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.white;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
