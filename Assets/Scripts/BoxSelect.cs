using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSelect : MonoBehaviour
{
    public Text mainTermin, selectedAnswer, correctAnswer, score;
    public GameObject[] buttons;
    public Color green, red;
    
    [SerializeField] private string termin, translate;
    private Animation anim;
    private int id;
    private int currentLvl;

    [SerializeField] private string correctTermin, correctTranslate;

    [SerializeField] GameObject restartWindow;

    [SerializeField] private List<int> selectedIDs = new List<int>();
    private List<int> buttonsCurrentWords = new List<int>() {-1, -1, -1, -1};

    private void Start()
    {
        reset();
        anim = GetComponent<Animation>();
        selectedIDs.Remove(0);
        currentLvl = 1;
    }

    public void Submit(int buttonID)
    {
        if (anim.isPlaying == false && currentLvl < Informations.amountOfTerminsInModule)
        {
            selectedAnswer.text = buttons[buttonID].GetComponentInChildren<Text>().text;
            if (mainTermin.text == correctTermin)
            {
                if (buttons[buttonID].GetComponentInChildren<Text>().text.ToLower() == correctTranslate.ToLower())
                {
                    selectedAnswer.color = green;
                }
                else
                {
                    selectedAnswer.color = red;
                    correctAnswer.color = green;
                    if (mainTermin.text == correctTermin)
                    {
                        correctAnswer.text = correctTranslate;
                    }
                    else
                    {
                        correctAnswer.text = correctTermin;
                    }
                }
            }
            else if (mainTermin.text == correctTranslate)
            {
                if (buttons[buttonID].GetComponentInChildren<Text>().text.ToLower() == termin.ToLower())
                {
                    selectedAnswer.color = green;
                }
                else
                {
                    selectedAnswer.color = red;
                    correctAnswer.color = green;
                    if (mainTermin.text == correctTermin)
                    {
                        correctAnswer.text = correctTranslate;
                    }
                    else
                    {
                        correctAnswer.text = correctTermin;
                    }
                }
            }
            anim.Play();
        }
    }

    public void reset()
    {
        currentLvl++;
        score.text = currentLvl + "/" + Informations.amountOfTerminsInModule;
        if (currentLvl == Informations.amountOfTerminsInModule)
        {
            restartWindow.GetComponent<RestartWindow>().ToggleActive(true);
            return;
        }

        selectedAnswer.text = null;
        correctAnswer.text = null;

        buttonsCurrentWords = new List<int>() {-1, -1, -1, -1};

        RandomWord(-1);
        int selectedButton = Random.Range(0, 4);
        buttons[selectedButton].GetComponentInChildren<Text>().text = correctTranslate;
        buttonsCurrentWords[selectedButton] = id;
        
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != selectedButton)
            {
                RandomWord(99);
                buttonsCurrentWords[i] = id;
                buttons[i].GetComponentInChildren<Text>().text = translate;
            }
        }
    }

    private void RandomWord(int buttonID)
    {

        if (buttonID == -1)
        {
            id = Random.Range(0, Informations.amountOfTerminsInModule - 1);
            while (selectedIDs.Contains(id))
            {
                id = Random.Range(0, Informations.amountOfTerminsInModule - 1);
            }
        }

        else
        {
            id = Random.Range(0, Informations.amountOfTerminsInModule - 1);
            while (buttonsCurrentWords.Contains(id))
            {
                id = Random.Range(0, Informations.amountOfTerminsInModule - 1);
            }
            
        }

        if (buttonID == -1)
        {
            correctTermin = Informations.currentModule[id].Replace("\"", "");
            if (Informations.tjMode)
            {
                correctTranslate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", "");
            }
            else
            {
                correctTranslate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
            }
        }
        else
        {
            termin = Informations.currentModule[id].Replace("\"", "");
            if (Informations.tjMode)
            {
                translate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 1].Replace("\"", "");
            }
            else
            {
                translate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
            }
        }

        if (buttonID == -1)
        {
            selectedIDs.Add(id);
            mainTermin.text = correctTermin;
        }
    }
}
