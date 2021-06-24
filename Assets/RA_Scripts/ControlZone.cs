using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZone : MonoBehaviour
{
    public int index = 0;
    private int previousIndex;
    private Color color;
    private void OnDrawGizmos()
    {
        if (index != previousIndex)
        {
            switch (index)
            {
                case 0:
                    color = Color.white;
                    break;
                case 1:
                    color = Color.green;
                    break;
                case 2:
                    color = Color.red;
                    break;
                case 3:
                    color = Color.blue;
                    break;
                case 4:
                    color = Color.cyan;
                    break;
                case 5:
                    color = Color.magenta;
                    break;
                case 6:
                    color = Color.yellow;
                    break;
                default:
                    Random.InitState(index);
                    color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    break;
            }
            GetComponent<SpriteRenderer>().color = color;
            previousIndex = index;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<RemoteControl>().SetIndex(index);
            Debug.Log("Zone: " + name);
        }
    }
}
