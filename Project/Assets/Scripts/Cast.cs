using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    GameObject[] fence,monsters;
    bool opened;
    int numom;

    void Start()
    {
        numom = transform.GetChild(1).transform.childCount;
        fence = new GameObject[6];
        monsters = new GameObject[numom];
        opened = false;
        for(int i = 0;i < 6;++i){
            fence[i] = transform.GetChild(0).GetChild(i).gameObject;
            fence[i].SetActive(false);
        }
        for(int i = 0;i < numom;++i){
            monsters[i] = transform.GetChild(1).GetChild(i).gameObject;
            monsters[i].SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if((!opened) && hitInfo.tag == "Player"){
            for(int i = 0;i < 6;++i)
                fence[i].SetActive(true);
            for(int i = 0;i < numom;++i)
                monsters[i].SetActive(true);
        }
    }

    void Update()
    {
        if(transform.GetChild(1).transform.childCount == 0)
        {
            opened = true;
            for(int i = 0;i < 6;++i)
                fence[i].SetActive(true);
        }
    }
}
