using System;
using UnityEngine;

public class Rand : MonoBehaviour
{
    System.Random rand = new System.Random();
    public int get(int l,int r)
    {return rand.Next(l,r);}
}
