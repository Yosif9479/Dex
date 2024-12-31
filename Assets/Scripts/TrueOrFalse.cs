using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueOrFalse : MonoBehaviour
{
    public Text word, word1, word2, word3;
    public string termin, translate;
    public Color green, red, Alpha;
    private Animation anim;
    private int id;
    private bool right;

    public void Awake()
    {
        reset();
        anim = GetComponent<Animation>();
    }

    public void Submit(string opt)
    {
        if (anim.isPlaying == false)
        {
            if (opt == "True")
            {
                word1.text = "Верно";
            }
            else if (opt == "False")
            {
                word1.text = "Неверно";
            }
            if (right == true)
            {
                if (word1.text == "Верно")
                {
                    word1.color = green;
                }
                else
                {
                    word1.color = red;
                    word2.text = "Верно";
                    word2.color = green;
                }
            }
            else if (right == false)
            {
                if (word1.text == "Неверно")
                {
                    word1.color = green;
                }
                else
                {
                    word1.color = red;
                    word2.text = "Неверно";
                    word2.color = green;
                }
            }
            anim.Play();
        }
    }

    public void reset()
    {
        word1.text = null;
        word2.text = null;
        RandomWord();
        word.text = termin;
        int i = Random.Range(0, 100);
        if (i > 50)
        {
            RandomWord();
            word3.text = translate;
            right = false;
        }
        else
        {
            word3.text = translate;
            right = true;
        }
    }

    private void RandomWord()
    {
        id = Random.Range(0, Informations.amountOfTerminsInModule - 1);
        termin = Informations.currentModule[id].Replace("\"", "");
        if (Informations.tjMode)
        {
            translate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", "");
        }
        else
        {
            translate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
        }
    }
}
