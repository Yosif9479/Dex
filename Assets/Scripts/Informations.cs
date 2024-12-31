using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class Informations : MonoBehaviour
{
    public static int stageId = 1;
    public static int moduleId = 4;
    public static int amountOfTerminsInModule = 39;
    public static bool tjMode;
    public static int spawnedTerminCards = 0;
    public static string[] currentModule;

    private void Start()
    {
        TextAsset textAsset = Resources.Load <TextAsset> ($"Dictionary/Test{stageId}/Lektion {moduleId}");
        string csvFile = textAsset.text;
        currentModule = csvFile.Split('\n');
    }
}