using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Variant_BS : MonoBehaviour
{
    private Text text;
    private Button button;
    private string word;

    public bool selected;
    
    public static List<int> alreadySelectedWords = new List<int>();

    public static UnityAction<string> SelectedRightVariant, SelectedWrongAnswer;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        button = GetComponent<Button>();

        button.onClick.AddListener(Submit);
        Word_BS.ResetWords += RandomWord;
        Word_BS.ToggleInteractableVariants += ToggleButtonsInteraction;
        
        RandomWord();
    }

    private void Submit()
    {
        
        if (text.text == Word_BS.currentTranslate)
        {
            SelectedRightVariant?.Invoke(text.text);
        }
        else
        {
            SelectedWrongAnswer?.Invoke(text.text);
        }
    }

    private void RandomWord()
    {
        if (!selected)
        {
            int id = Random.Range(0, Informations.amountOfTerminsInModule);

            while (alreadySelectedWords.Contains(id))
            {
                id = Random.Range(0, Informations.amountOfTerminsInModule);
            }

            if (Informations.tjMode)
            {
                word = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", null);
            }
            else
            {
                word = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", null);
            }

            alreadySelectedWords.Add(id);
        }
        else
        {
            word = Word_BS.currentTranslate;
        }
        
        text.text = word;
    }

    private void ToggleButtonsInteraction()
    {
        button.interactable = !button.interactable;
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Submit);
        Word_BS.ResetWords -= RandomWord;
        Word_BS.ToggleInteractableVariants -= ToggleButtonsInteraction;
    }
}
