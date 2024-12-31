using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCard : MonoBehaviour
{
    public Color selectedColor, textBlackColor;
    public int id;
    private Animation anim;
    private bool selected;
    private Text word;
    private string termin, translate;
    public string wordType;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        word = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        SelectionSystem.allCards.Add(gameObject);
        selected = false;
    }

    public void Update()
    {
        if (id >= 0)
        {
            RandomWord();
        }
    }

    public void Select()
    {
        if (selected == false)
        {
            if (SelectionSystem.cards.Count < 2)
            {
                selected = !selected;
                SelectionSystem.cards.Add(gameObject);
                GetComponent<Image>().color = selectedColor;
                if (SelectionSystem.cards.Count == 2)
                {
                    SelectionSystem.Compare();
                }
                word.color = Color.white;
            }
        }
        else if (selected == true && SelectionSystem.cards.Count == 1)
        {
            selected = !selected;
            GetComponent<Image>().color = Color.white;
            SelectionSystem.cards.Remove(gameObject);
            word.color = textBlackColor;
        }
    }

    public void StartAnimation(string animation)
    {
        anim.PlayQueued(animation);
    }

    public void Remove(string destroy)
    {
        SelectionSystem.cards.Remove(gameObject);
        if (destroy == "True")
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Image>().color = Color.white;
            word.color = textBlackColor;
        }
        selected = !selected;
    }

    public void RandomWord()
    {
        termin = Informations.currentModule[id].Replace("\"", "");
        if (Informations.tjMode)
        {
            translate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", "");
        }
        else
        {
            translate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
        }
        if (wordType == "Termin")
        {
            word.text = termin;
        }
        else if (wordType == "Translate")
        {
            word.text = translate;
        }
    }
}