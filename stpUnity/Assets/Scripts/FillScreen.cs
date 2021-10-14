using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreen : MonoBehaviour
{
    

    public Camera cam;
    public float distanceFromCamera;
    // Update is called once per frame
    void Update()
    {
        float pos = (cam.nearClipPlane + distanceFromCamera);

        transform.position = cam.transform.position + cam.transform.forward * pos;
        transform.LookAt(cam.transform);
        transform.Rotate(90.0f, 0.0f, 0.0f);

        float h = (Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * pos * 2f) / 10.0f;
        transform.localScale = new Vector3(h * cam.aspect, 1.0f, h);

    }
}
