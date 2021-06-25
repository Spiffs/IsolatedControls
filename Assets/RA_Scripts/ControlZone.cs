using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlZone : MonoBehaviour
{
    public int index = 0;
    public bool killZone = false;
    public bool winZone = false;
    private int previousIndex;
    private Color color;
    private void OnDrawGizmos()
    {
        if (winZone == true)
        {
            index = 0;
        }
        if (index != previousIndex)
        {
            if (!killZone)
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
                        color = Color.gray;
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
            }
            else
            {
                color = Color.red;
            }
            GetComponent<SpriteRenderer>().color = color;
            previousIndex = index;
        }
        if (killZone)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (killZone)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            collision.GetComponent<RemoteControl>().SetIndex(index);
            Debug.Log("Zone: " + name);
        }
    }
}
