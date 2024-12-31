using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class TerminCard : MonoBehaviour
{
    private int id;
    
    [SerializeField] private Text Word;
    [SerializeField] private Text num;

    private string termin;
    private string translate;
    

    private void Start()
    {
        id = Informations.spawnedTerminCards;
        Informations.spawnedTerminCards++;

        termin = Informations.currentModule[id].Replace("\"", "");
        if (Informations.tjMode)
        {
            translate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", "");
        }
        else
        {
            translate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
        }

        Word.text = termin;
        num.text = System.Convert.ToString(id + 1);
    }

    public void turnOver()
    {
        transform.GetComponent<Animation>().Play("turnOver");
    }
    public void reText()
    {
        if (Word.text == termin)
        {
            Word.text = translate;
        }
        else if (Word.text == translate)
        {
            Word.text = termin;
        }
    }
}
