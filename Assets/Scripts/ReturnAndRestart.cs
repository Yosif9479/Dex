using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAndRestart : MonoBehaviour
{
    public static string rest;

    public void Start()
    {
        rest = "";    
    }

    public void ReturnLast()
    {
        rest = "returnLast";
    }
    public void Restart()
    {
        rest = "restart";
    }
}
