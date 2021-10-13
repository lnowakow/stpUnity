using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.iOS;

public class Cursor : MonoBehaviour
{
    private bool overSprite;
    private float overSpriteTimer;
    public string button = null;
    public bool isClicked;

    public float requiredHoldTime;

    public Transform loadingBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.name == "CursorButton" ||
            other.name == "rPSMButton" ||
            other.name == "vPSMButton" ||
            other.name == "FollowButton")
        {
        
        } 
        else
        {
        */
        overSprite = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        button = other.name;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (overSprite)
        {
            overSpriteTimer += Time.deltaTime;
            if (overSpriteTimer > requiredHoldTime)
            {
                Debug.Log("You clicked the button " + other.name);
                gameObject.transform.parent.transform.GetComponent<MenuStateManager>().SwitchState(
                    gameObject.transform.parent.transform.GetComponent<MenuStateManager>().menu_states[other.name]);
                Reset();
            }

            loadingBar.localScale = new Vector3((overSpriteTimer / requiredHoldTime) * 0.1f, 0.02f, 1.0f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Reset();
    }

    private void Reset()
    {
        button = null;
        isClicked = false;
        overSprite = false;
        overSpriteTimer = 0;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        loadingBar.localScale = new Vector3(0.0f, 0.02f, 1.0f);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
}
