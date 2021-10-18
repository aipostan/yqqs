using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    PlayerState state;

    void Start(){
        state = GameObject.Find("player").GetComponent<PlayerState>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        switch (hitInfo.tag){
            case "spcoin":
                state.changesp(8);
                Destroy(hitInfo.gameObject);
                break;
            case "Gcoin":
                state.changemoney(3);
                Destroy(hitInfo.gameObject);
                break;
            case "Ccoin":
                state.changemoney(1);
                Destroy(hitInfo.gameObject);
                break;
        }
    }
}