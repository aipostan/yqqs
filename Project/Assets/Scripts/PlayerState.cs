using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerState : MonoBehaviour
{
    int hp,sp,shp,money;
    float skilt,lshpt;

    public bool issk,isdied,isready;

    public Text hps,sps,shps,skills,moneys;
    public Image hpt,spt,shpt,skillt;

    void Start()
    {
        hp = 7;shp = 6;sp = 200;money = 0;
        isdied = issk = false;
        isready = true;
        lshpt = skilt = 0f;
        hps.text = hp.ToString();
        shps.text = shp.ToString();
        sps.text = sp.ToString();
        moneys.text = money.ToString();
        hpt.fillAmount = hp / 7f;
        shpt.fillAmount = shp / 6f;
        spt.fillAmount = sp / 200f;
        skillt.fillAmount = 1;
    }

    void Update()
    {
        skilt += Time.deltaTime;

        if(isready){
            skills.text = "Ready";
        }else{
            if(issk){
                skills.text = (Math.Floor(100f - skilt * 10f) / 10f).ToString();
                skillt.fillAmount = (10f - skilt) / 10f;
            }else{
                skills.text = (Math.Floor(200f - skilt * 10f) / 10f).ToString();
                skillt.fillAmount = skilt / 20f;
            }
        }

        if(isready){
            if(Input.GetMouseButtonDown(1))
            {skilt = 0f;isready = false;issk = true;}
        }else{
            if(issk){
                if(skilt > 10.0f)
                {skilt = 0f;issk = false;}
            }else{
                if(skilt > 20.0f)
                {skilt = 0f;isready = true;}
            }
        }

        updateshp();
    }

    void updateshp()
    {
        lshpt -= Time.deltaTime;
        if(lshpt < 0f)
            if(shp < 6)
            {shp ++;lshpt = 2.0f;}
        shps.text = shp.ToString();
        shpt.fillAmount = shp / 6.0f;
    }

    public void changehp(int delta)
    {
        if(delta > 0)
            if((hp += delta) > 7)
                hp = 7;
        else{
            lshpt = 2.0f;
            shp += delta;
            if(shp < 0){
                hp += shp;
                shp = 0;
                if(hp < 0)
                    hp = 0;
            }
        }
        hpt.fillAmount = hp / 7.0f;
        hps.text = hp.ToString();
        if(hp == 0)
            died();
    }

    public bool changesp(int delta)
    {
        bool ret = true;
        sp += delta;
        if(sp > 200)
            sp = 200;
        if(sp < 0)
        {sp -= delta;ret = false;}
        sps.text = sp.ToString();
        spt.fillAmount = sp / 200.0f;
        return ret;
    }

    public bool changemoney(int delta)
    {
        bool ret =true;
        money += delta;
        if(money < 0)
        {money -= delta;ret = false;}
        moneys.text = money.ToString();
        return ret;
    }

    void died(){isdied = true;Destroy(gameObject);}
}