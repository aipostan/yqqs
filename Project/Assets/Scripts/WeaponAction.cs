using System;
using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {    
        Vector3 lkat = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.LookAt(lkat);
        transform.Rotate(new Vector3(0,-90,0));


    }

}