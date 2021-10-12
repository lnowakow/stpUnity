using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Cursor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       gameObject.GetComponentInParent<MenuStateManager>().optionSelected = other.name;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponentInParent<MenuStateManager>().optionSelected = "none";
    }
}
