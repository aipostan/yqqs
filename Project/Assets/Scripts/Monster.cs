using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Monster : MonoBehaviour
{
    public GameObject spcoin,Gcoin,Ccoin;
    public int health,dmg;
    public bool isdied,ended;
    public float speed = 3f,nextWaypointDistance = 3f;

    public Transform target;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;

    Rand rander;

    public void takedamage(int d){health -= d;if(health <= 0)die();}

    void Start()
    {
        isdied = false;
        if(gameObject.layer == 7){
            seeker = GetComponent<Seeker>();
            rb = GetComponent<Rigidbody2D>();
            InvokeRepeating("UpdatePath",0f,3f);
        }
        rander = GameObject.Find("rand").GetComponent<Rand>();
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position,target.position,OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if(gameObject.layer == 7)
        {
            if(path == null)return;
            if(currentWaypoint >= path.vectorPath.Count)
            {ended = true;return;}
            else    ended = false;
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position,path.vectorPath[currentWaypoint]);

            if(distance < nextWaypointDistance) ++currentWaypoint;

            if(force.x > 0f)
                transform.localRotation = Quaternion.Euler(0,0,0);
            if(force.x < 0f)
                transform.localRotation = Quaternion.Euler(0,180,0);
        }
    }

    void die()
    {
        isdied = true;
        if(gameObject.layer == 7)
            for(int i = rander.get(2,6);i>0;-- i){
                switch(rander.get(0,5)){
                case 0:
                    Instantiate(Gcoin,transform.position,transform.rotation);
                    break;
                default:
                    Instantiate(Ccoin,transform.position,transform.rotation);
                    break;
                }
            }
        if(rander.get(0,5) > 2)
            Instantiate(spcoin,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
