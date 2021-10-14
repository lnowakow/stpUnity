using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class UIPlane : MonoBehaviour
{
    public Camera camL;
    public Camera camR;
    public float distanceFromCamera;
    private float sizeOfMenu = 3.5f;
    // Update is called once per frame
    void Update()
    {
        float avgClipPlane = (camL.nearClipPlane + camR.nearClipPlane) / 2.0f;
        float pos = (avgClipPlane + distanceFromCamera);

        Camera CenterCamera = camL;
        CenterCamera.transform.position = (camL.transform.position + camR.transform.position) / 2.0f;
        
        transform.position = CenterCamera.transform.position + CenterCamera.transform.forward * pos;
        transform.LookAt(CenterCamera.transform);
        transform.Rotate(0.0f, 0.0f, 0.0f);

        float h = (Mathf.Tan(CenterCamera.fieldOfView * Mathf.Deg2Rad * 0.5f) * pos * 2f) / (10.0f*sizeOfMenu);
        transform.localScale = new Vector3(h * CenterCamera.aspect, h, 1.0f);

    }
}
