using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedAnswer_BS : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        Variant_BS.SelectedRightVariant += True;
        Variant_BS.SelectedWrongAnswer += False;
        Word_BS.ResetWords += reset;
    }

    private void True(string word)
    {
        text.color = Color.green;
        text.text = word;
    }

    private void False(string word)
    {
        text.text = word;
        text.color = Color.red;
    }

    private void reset()
    {
        text.color = new Color(0, 0, 0, 0);
    }

    private void OnDestroy()
    {
        Variant_BS.SelectedRightVariant -= True;
        Variant_BS.SelectedWrongAnswer -= False;
        Word_BS.ResetWords -= reset;
    }
}
