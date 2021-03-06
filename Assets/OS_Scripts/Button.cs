using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UILib;

public class Button : MonoBehaviour
{
    [SerializeField]
    private ButtonID LocalButtonID;

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
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // collider check
            if (collider.OverlapPoint(mp))
            {
                IsPressed = true;
            }
            
        }
    }

    public ButtonID GetButtonID()
    {
        return LocalButtonID;
    } // returns the button ID

    public bool GetPressed()
    {
        return IsPressed;
    } // returns if the button is pressed or not
}
