using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 4.0f,speed2 = 2.8f;
    public bool ifmov;

    float xVelocity,yVelocity;
    
    void Start()
    {rb = GetComponent<Rigidbody2D>();}

    void Update()
    {Move();}

    void Move()
    {
        xVelocity = Input.GetAxis("Horizontal");
        yVelocity = Input.GetAxis("Vertical");
        if(xVelocity*yVelocity != 0f)
            rb.velocity = new Vector2(xVelocity * speed2,yVelocity * speed2);
        else
            rb.velocity = new Vector2(xVelocity * speed,yVelocity * speed);
        ifmov = !(xVelocity == 0f && yVelocity == 0f);
        if(xVelocity != 0f){
            if(xVelocity < 0f)
                transform.localScale = new Vector2(-1,1);
            else
                transform.localScale = new Vector2(1,1);
//            GameObject.Find("weapons").GetComponent<WeaponAction>().rev(xVelocity);
        }
    }
}
