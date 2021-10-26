using System;
using System.Collections;
using System.Collections.Generic;
using Footpedals;
using UnityEditor;
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
        gameObject.transform.Find("SelectionTimeOutBackground").gameObject.SetActive(true);
        gameObject.transform.Find("SelectionTimeOut").gameObject.SetActive(true);
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
                //string newState = other.name.Replace("Button", "State");
                //gameObject.transform.root.GetComponent<ConsoleStateManager>().SwitchState(
                //    gameObject.transform.root.GetComponent<ConsoleStateManager>().ConsoleState[newState]);
                GetComponentInParent<MenuStateManager>().SwitchState(
                    GetComponentInParent<MenuStateManager>().MenuState[other.name]);
                gameObject.transform.root.Find("Footpedals").GetComponent<FootpedalStateManager>().SwitchState(
                    gameObject.transform.root.Find("Footpedals").GetComponent<FootpedalStateManager>().FootpedalState["WaitState"]);
                
                // Reset cursor position to middle of screen
                transform.position = new Vector3(0, 0, 0);
                
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
