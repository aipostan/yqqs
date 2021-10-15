using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerState : MonoBehaviour
{
    public int hp,sp,shp,weaponindex;
    public float passedt,skt;
    public bool issk;

    public Text hps,sps,shps,skills;

    void Start()
    {
        hp = 7;shp = 6;sp = 200;issk = false;skt = 0f;passedt = 30.0f;
        hps.text = hp.ToString();
        shps.text = shp.ToString();
        sps.text = sp.ToString();
    }

    void Update(){
        passedt += Time.deltaTime;
        skt += Time.deltaTime;
        if(passedt>=30.0f && Input.GetMouseButtonDown(1))
        {passedt = 0f;skt = 0f;issk = true;}
        if(skt>10f)
            issk = false;
        if(passedt>30.0f)
            skills.text = "Ready";
        else
            skills.text = (Math.Floor(300.0f-passedt*10.0f)/10.0f).ToString();
    }
    
}
