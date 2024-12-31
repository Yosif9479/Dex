using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Write : MonoBehaviour
{
    private const string SPECIAL_SYMBOLS = "/•,.()-:\"";

    public static string currentTermin, currentTranslate;

    private Text text, selectedText, currentText;
    private Animation m_animation;

    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _submitButton;

    private void Start()
    {
        text = GetComponent<Text>();
        selectedText = GetComponentsInChildren<Text>()[1];
        currentText = GetComponentsInChildren<Text>()[2];
        m_animation = GetComponent<Animation>();

        _submitButton.onClick.AddListener(Submit);

        RandomWord();
    }

    private void Submit()
    {
        if (!m_animation.isPlaying)
        {
            string selectedTranslate = GetNormalized(_inputField.text);

            selectedText.text = _inputField.text;
            
            Debug.Log($"{selectedTranslate} {currentTranslate}");
            
            if (selectedTranslate == currentTranslate)
            {
                selectedText.color = Color.green;
            }
            else
            {
                selectedText.color = Color.red;
                currentText.color = Color.green;
            }

            m_animation.Play("Go");
        }
    }

    protected void reset()
    {
        m_animation.Play("Start");
        _inputField.text = null;
        selectedText.color = new Color(0, 0, 0, 0);
        currentText.color = new Color(0, 0, 0, 0);
        RandomWord();
    }

    private void RandomWord()
    {
        int id = Random.Range(0, Informations.amountOfTerminsInModule);
        
        currentTermin = Informations.currentModule[id];
        
        if (Informations.tjMode)
        {
            currentTranslate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2];
        }
        else
        {
            currentTranslate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1];
        }

        text.text = currentTermin.Replace("\"", null);
        currentText.text = currentTranslate.Replace("\"", null);

        currentTermin = GetNormalized(currentTermin);
        currentTranslate = GetNormalized(currentTranslate);
    }

    private string GetNormalized(string target)
    {
        foreach(char i in SPECIAL_SYMBOLS)
        {
            target = target.Replace(i.ToString(), null);
        }
        target = target.ToLower();
        target = target.Trim();

        return target;
    }

    private void OnDestroy()
    {
        _submitButton.onClick.RemoveListener(Submit);
    }
}
