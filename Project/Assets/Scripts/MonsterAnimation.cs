using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    Animator anim;
    Monster state;
    float v;

    void Start()
    {
        anim = GetComponent<Animator>();
        state = GetComponent<Monster>();
    }

    void Update()
    {
        anim.SetBool("move",!state.ended);
        anim.SetBool("died",state.isdied);
    }
}
