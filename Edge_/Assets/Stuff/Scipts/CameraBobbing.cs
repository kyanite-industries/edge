using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraBobbing : MonoBehaviour
{
    [Header("Transform references")]
    public Transform headTransform;
    public Transform cameraTransform;
    [Header("Head bobbing")]
    public float bobFrequency = 5f;
    public float bobHorizonaAmplitude = 8.1f;
    public float bobVerticalAmplitude = 0.1f;[Range(0, 1)]
    public float headBobSmoothing = 8.1f;
    // State 
    public bool isMoving; 
    private float walkingTime; 
    private Vector3 targetCameraPosition;
    private void Update()
    {
        isMoving = (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));
        if (!isMoving) walkingTime = 0; 
        else walkingTime += Time.deltaTime;
        targetCameraPosition = headTransform.position + CalculateHeadBoboffset(walkingTime);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCameraPosition, headBobSmoothing);
        if ((cameraTransform.position - targetCameraPosition).magnitude <= 0.001) cameraTransform.position = targetCameraPosition;
    }
    private Vector3 CalculateHeadBoboffset(float t)
    {
        float horizontaloffset = 0; float verticaloffset = 0; Vector3 offset = Vector3.zero;
        if (t > 0)
            horizontaloffset = Mathf.Cos(t * bobFrequency) * bobHorizonaAmplitude;
            verticaloffset = Mathf.Sin(t * bobFrequency * 2) * bobVerticalAmplitude;
            offset = headTransform.right * horizontaloffset + headTransform.up * verticaloffset;
            return offset;
    }
}
