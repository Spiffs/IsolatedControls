using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // door objects 
    [SerializeField]
    private GameObject RedDoor;

    [SerializeField]
    private GameObject BlueDoor;

    void Start()
    {
        RedDoor.SetActive(true);
        BlueDoor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedDoorActivate()
    {
        if (RedDoor.activeSelf == true)
            RedDoor.SetActive(false);
        else
            RedDoor.SetActive(true);
    }

    public void BlueDoorActivate()
    {
        if (BlueDoor.activeSelf == true)
            BlueDoor.SetActive(false);
        else
            BlueDoor.SetActive(true);
    }
}
