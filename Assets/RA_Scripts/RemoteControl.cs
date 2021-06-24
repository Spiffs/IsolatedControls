using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControl : MonoBehaviour
{
    public float speed;
    private Vector2 moveDir = new Vector2(0,0);
    private int index;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        //temp:
        //Check Button Inputs
        //int moveingLeft = boutt ? 1 : 0;
        //Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 curPos = new Vector2(transform.position.x, transform.position.y);
        GetComponent<Rigidbody2D>().MovePosition(curPos + moveDir);
    }
    public void Up()
    {
        moveDir.y += speed;
    }
    public void Down()
    {
        moveDir.y -= speed;
    }
    public void Left()
    {
        moveDir.x -= speed;
    }
    public void Right()
    {
        moveDir.x += speed;
    }
    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int newIndex)
    {
        index = newIndex;
    }
}
