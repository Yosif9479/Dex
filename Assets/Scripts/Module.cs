using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Module : MonoBehaviour
{
    public int id;
    public Text NameOfModule;
    public Text AmountOfTermins;
    void Start()
    {
        if (Informations.stageId % 2 == 0)
        {
            NameOfModule.text = "Lektion " + (id + 12);
        }
        else
        {
            NameOfModule.text = "Lektion " + id;
        }
        string csvFile = Resources.Load<TextAsset>($"Dictionary/Test{Informations.stageId}/Lektion {id}").text;
        string[] currentModule = csvFile.Split('\n');
        AmountOfTermins.text = ((currentModule.Length / 3) - 1) + " Begriffe";
    }
    public void SetModule()
    {
        string csvFile = Resources.Load<TextAsset>($"Dictionary/Test{Informations.stageId}/Lektion {id}").text;
        string[] currentModule = csvFile.Split('\n');
        Informations.moduleId = id;
        Informations.amountOfTerminsInModule = (currentModule.Length / 3) - 1;
    }
}