using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    float speed = 4.0f,speed2 = 2.9f;

    public bool ifmov;
    
    void Start()
    {rb = GetComponent<Rigidbody2D>();}

    void Update()
    {Move();}

    void Move()
    {
        float xVelocity = Input.GetAxis("Horizontal");
        float yVelocity = Input.GetAxis("Vertical");
        if(xVelocity*yVelocity != 0f)
            rb.velocity = new Vector2(xVelocity * speed2,yVelocity * speed2);
        else
            rb.velocity = new Vector2(xVelocity * speed,yVelocity * speed);
        ifmov = !(xVelocity == 0f && yVelocity == 0f);
        if(xVelocity != 0f){
            if(xVelocity > 0)
                transform.localRotation = Quaternion.Euler(0,0,0);
            else
                transform.localRotation = Quaternion.Euler(0,180,0);
        }
    }
}
