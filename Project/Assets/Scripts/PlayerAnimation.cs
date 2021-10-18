using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;
    PlayerState state;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        state = GetComponent<PlayerState>();
    }

    void Update()
    {
        anim.SetBool("move",movement.ifmov);
        anim.SetBool("died",state.isdied);
    }
}
