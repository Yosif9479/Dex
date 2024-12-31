using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChange : MonoBehaviour
{
    private Image img;
    public Sprite[] images;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Start()
    {
        if (Informations.tjMode == true)
        {
            img.sprite = images[0];
        }
        else
        {
            img.sprite = images[1];
        }
    }

    public void Click()
    {
        if (Informations.tjMode == true)
        {
            img.sprite = images[1];
        }
        else
        {
            img.sprite = images[0];
        }
        Informations.tjMode = !Informations.tjMode;
    }
}
