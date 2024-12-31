using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_BS : MonoBehaviour
{
    private Text text;
    private int currentScore, maxScore;

    [SerializeField] private GameObject _restartMenu;

    private void Awake()
    {
        text = GetComponent<Text>();

        currentScore = 1;
        maxScore = Informations.amountOfTerminsInModule;

        Word_BS.ResetWords += UpdateScore;

        UpdateScore();
    }

    private void UpdateScore()
    {
        currentScore = Word_BS.alreadySelectedWords.Count;
        if (text != null)
        {
            text.text = $"{currentScore}/{maxScore}";
        }
        CheckIfScoreMax();
    }

    private void CheckIfScoreMax()
    {
        if (currentScore == maxScore)
        {
            Word_BS.ToggleInteractableVariants?.Invoke();
            _restartMenu.SetActive(true);
        }
    }
}
