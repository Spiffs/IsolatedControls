using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZone : MonoBehaviour
{
    public int index = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<RemoteControl>().SetIndex(index);
            Debug.Log("Zone: " + name);
        }
    }
}
