using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // access to panel brain
    private GameObject ControlPanelObject; 

    private string PanelPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // sets the panel position code
    public void SetPanelPosition(char newRowPos, int newColumPos)
    {
        string newPosition = newRowPos.ToString() + newColumPos.ToString();
        PanelPosition = newPosition;
    }

    // sets the control brain object 
    public void SetControlPanelBrain(GameObject controlPanel)
    {
        ControlPanelObject = controlPanel;
    }

}
