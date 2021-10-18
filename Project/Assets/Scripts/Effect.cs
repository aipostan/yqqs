using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Animator anim;
    PlayerState state;
    GameObject weapon4skill;
    void Start()
    {
        anim = GetComponent<Animator>();
        state = GameObject.Find("player").GetComponent<PlayerState>();
        weapon4skill = GameObject.Find("weaponforskill");
    }

    void Update()
    {        
        anim.SetBool("inskill",state.issk);
        anim.SetBool("died",state.isdied);
        if(state.issk)
            weapon4skill.SetActive(true);
    }
}