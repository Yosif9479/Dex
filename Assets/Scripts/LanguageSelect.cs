using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelect : MonoBehaviour
{
    private Animation _animation;

    private void Start()
    {
        Informations.tjMode = Convert.ToBoolean(PlayerPrefs.GetInt("tjMode"));
        _animation = GetComponent<Animation>();
        if (!PlayerPrefs.HasKey("firstStart"))
        {
            PlayerPrefs.SetInt("firstStart", 1);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetLanguage(bool language)
    {
        Informations.tjMode = language;
        ToggleActive(true);
        PlayerPrefs.SetInt("tjMode", Convert.ToInt32(language));
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ToggleActive(bool playAnimation)
    {
        if (gameObject.activeInHierarchy)
        {
            _animation.Play("Finish");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
