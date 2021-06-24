using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UILib;

public class Button : MonoBehaviour
{
    public ButtonID LocalButtonID;

    private bool IsPressed;

    private Collider2D collider;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsPressed = false;

        if (Input.GetMouseButtonDown(0))
        {
            // mouse position
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // collider check
            if (collider.OverlapPoint(mp))
            {
                IsPressed = true;
            }
            
        }
    }

    public bool GetPressed()
    {
        return IsPressed;
    } // returns if the button is pressed or not
}
