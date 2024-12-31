using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Word_BS : MonoBehaviour
{
    [SerializeField] private Button[] _variants;
    
    private Text text;
    private Animation m_animation;

    public static List<int> alreadySelectedWords = new List<int>();

    public static string currentWord, currentTranslate;
    public static int currentWordsID;

    public static UnityAction ResetWords, ToggleInteractableVariants;

    private void Start()
    {
        text = GetComponent<Text>();
        m_animation = GetComponent<Animation>();

        Variant_BS.SelectedRightVariant += reset;
        Variant_BS.SelectedWrongAnswer += reset;

        currentWord = null;
        currentTranslate = null;
        currentWordsID = 0;

        alreadySelectedWords.Clear();

        RandomWord();
    }

    private void SelectRandomVariant()
    {
        foreach (Button i in _variants)
        {
            i.GetComponent<Variant_BS>().selected = false;
        }

        Variant_BS.alreadySelectedWords.Clear();
        Variant_BS.alreadySelectedWords.Add(currentWordsID);

        int id = Random.Range(0, _variants.Length);

        _variants[id].GetComponent<Variant_BS>().selected = true;

        ResetWords?.Invoke();
    }

    private void RandomWord()
    {
        int id = Random.Range(0, Informations.amountOfTerminsInModule);

        while (alreadySelectedWords.Contains(id))
        {
            id = Random.Range(0, Informations.amountOfTerminsInModule);
        }

        currentWord = Informations.currentModule[id].Replace("\"", null);

        if (Informations.tjMode)
        {
            currentTranslate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", null);
        }
        else
        {
            currentTranslate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", null);
        }

        currentWordsID = id;
        alreadySelectedWords.Add(id);

        text.text = currentWord;

        SelectRandomVariant();
    }

    private void reset(string word)
    {
        m_animation.Play("Reset");
    }

    protected void ResetPosition()
    {
        m_animation.Play("Start");
        RandomWord();
    }

    protected void ToggleButtonsInteraction()
    {
        ToggleInteractableVariants?.Invoke();
    }

    private void OnDestroy()
    {
        Variant_BS.SelectedWrongAnswer -= reset;
        Variant_BS.SelectedRightVariant -= reset;
    }
}
