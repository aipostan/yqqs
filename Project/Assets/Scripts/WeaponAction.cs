using System;
using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    PlayerState state;
   
    public float bps;
    public bool isskil;

    public int[,] weapons = {{1,1},{100,100}};
        //y:0:dmg;1:sp
    float passedt;
    int index;

    void Start()
    {
        index = 0;
        state = GameObject.Find("player").GetComponent<PlayerState>();
    }

    void Update()
    {   
        if(state.isdied)Destroy(gameObject);

        if(isskil && !state.issk)
            gameObject.SetActive(false);

        passedt += Time.deltaTime;

        Vector2 lkat = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.LookAt(lkat);
        transform.Rotate(new Vector2(0,-90));

        if(passedt>bps)
            if(Input.GetMouseButtonDown(0)){
                if(state.changesp(-weapons[index,1]))
                    Instantiate(projectile,shotPoint.position,transform.rotation);
                passedt = 0;
            }
    }

    public int requstfordmg(){return weapons[index,0];}
}