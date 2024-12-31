using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URL : MonoBehaviour
{
    public void Go(string url)
    {
        Application.OpenURL(url);
    }

    public void Rate()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
