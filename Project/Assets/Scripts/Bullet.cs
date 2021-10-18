using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed,lifeTime;
    public Rigidbody2D rb;

    int damage;

    void Start()
    {
        damage = GameObject.Find("weapons").GetComponent<WeaponAction>().requstfordmg();
        Invoke("destroy",lifeTime);
        rb.velocity = transform.right * speed;
    }

    void destroy(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        switch(hitInfo.tag){
            case "Monster":
                Monster ene = hitInfo.GetComponent<Monster>();
                if(ene != null){
                    ene.takedamage(damage);
                    destroy();
                }
                break;
            case "Wall":
                destroy();
                break;
        }
    }
}