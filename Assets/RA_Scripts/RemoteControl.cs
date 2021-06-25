using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControl : MonoBehaviour
{
    public float speed = 1;
    public bool slideMovement = false;

    private Vector2 moveDir = new Vector2(0,0);
    private int index;
    private bool movementInput = false;
    private Vector2 curPos = new Vector2(0, 0);
    private Vector2 previousPos = new Vector2(0, 0);
    private Rigidbody2D rb;
    void Start()
    {
        curPos = new Vector2(transform.position.x, transform.position.y);
        previousPos = curPos;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // temp:
        //Check Button Inputs
        if (Input.GetAxis("Vertical") > 0)
        {
            Up();
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Down();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Left();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Right();
        }
        // !temp:

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
        if (slideMovement == false)
        {
            Stop();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //curPos = new Vector2(transform.position.x, transform.position.y);
        //if (!slideMovement)
        //{
        //    Stop();
        //}
        //if (curPos == previousPos && movementInput == true)
        //{
        //    Stop();
        //}
        //else if (movementInput == true)
        //{
        //    previousPos = curPos;
        //}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Stop();
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stop();
    }
    public void Up()
    {
        if (movementInput == false)
        {
            moveDir.y = 1;
        }
        movementInput = true;
    }
    public void Down()
    {
        if (movementInput == false)
        {
            moveDir.y = -1;
        }
        movementInput = true;
    }
    public void Left()
    {
        if (movementInput == false)
        {
            moveDir.x = -1;
        }
        movementInput = true;
    }
    public void Right()
    {
        if (movementInput == false)
        {
            moveDir.x = 1;
        }
        movementInput = true;
    }
    //public void Up()
    //{
    //    if (movementInput != true || slideMovement == false)
    //    {
    //        moveDir.y += 1;
    //    }
    //    movementInput = true;
    //}
    //public void Down()
    //{
    //    if (movementInput != true || slideMovement == false)
    //    {
    //        moveDir.y -= 1;
    //    }
    //    movementInput = true;
    //}
    //public void Left()
    //{
    //    if (movementInput != true || slideMovement == false)
    //    {
    //        moveDir.x -= 1;
    //    }
    //    movementInput = true;
    //}
    //public void Right()
    //{
    //    if (movementInput != true || slideMovement == false)
    //    {
    //        moveDir.x += 1;
    //    }
    //    movementInput = true;  
    //}
    public void Stop()
    {
        moveDir = new Vector2(0, 0);
        movementInput = false;
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
