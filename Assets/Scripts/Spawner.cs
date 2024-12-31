using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject TerminCard;
    public GameObject learningCard;
    public string Titem;
    public Camera cam;
    public Text leftNum;
    public Text rightNum;
    public void Start()
    {
        Spawn(Titem);
        Cards.focus = 0;
    }
    public void Spawn(string item)
    {
        if (item == "TerminCards")
        {
            Informations.spawnedTerminCards = 0;
            for (int i = 0; i < Informations.amountOfTerminsInModule; i++)
            {
                Instantiate(TerminCard, transform);
            }
        }
        else if (item == "learningCards")
        {
            for (int i = Informations.amountOfTerminsInModule; i > 0; i--)
            {
                learningCard.GetComponent<Cards>().cam = cam;
                learningCard.GetComponent<Cards>().leftNumT = leftNum;
                learningCard.GetComponent<Cards>().rightNumT = rightNum;
                Instantiate(learningCard, transform).GetComponent<Cards>().id = i - 1;
            }
        }
    }
}