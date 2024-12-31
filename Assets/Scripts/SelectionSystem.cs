using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    public static List<GameObject> cards;
    public static List<GameObject> allCards;
    public Button restartButton;
    private int wordId;
    private List<int> selectedIds;
    private void Awake()
    {
        cards = new List<GameObject>();
        allCards = new List<GameObject>();
    }

    private void Start()
    {
        selectedIds = new List<int>();
    }

    public void Update()
    {
        if (allCards.Count == 12)
        {
            for (int i = 12; i != 0; i--)
            {
                int obj = Random.Range(0, allCards.Count - 1);
                if (i % 2 == 0)
                {
                    while (selectedIds.Contains(wordId))
                    {
                        wordId = Random.Range(0, Informations.amountOfTerminsInModule - 1);
                    }
                    allCards[obj].GetComponent<SelectionCard>().id = wordId;
                    allCards[obj].GetComponent<SelectionCard>().wordType = "Termin";
                    selectedIds.Add(wordId);
                    allCards.RemoveAt(obj);
                }
                else
                {
                    allCards[obj].GetComponent<SelectionCard>().id = wordId;
                    allCards[obj].GetComponent<SelectionCard>().wordType = "Translate";
                    allCards.RemoveAt(obj);
                }

            }
        }
        if (GameObject.FindGameObjectsWithTag("Card").Length == 0)
        {
            restartButton.interactable = true;
            restartButton.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    public static void Compare()
    {
        if (cards[0].GetComponent<SelectionCard>().id == cards[1].GetComponent<SelectionCard>().id)
        {
            foreach (GameObject card in cards)
            {
                card.GetComponent<SelectionCard>().StartAnimation("True");
            }
        }
        else
        {
            foreach (GameObject card in cards)
            {
                card.GetComponent<SelectionCard>().StartAnimation("False");
            }
        }
    }
}