using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEye : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        print("Number of devices found: " + devices.Length);
        for (int i = 0; i < devices.Length; i++) {
            print("Webcam available: " + devices[i].name);
        }

        Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired
        WebCamTexture tex = new WebCamTexture(devices[2].name);
        rend.material.mainTexture = tex;
        tex.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
