using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAnswer_BS : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        Variant_BS.SelectedWrongAnswer += False;
        Word_BS.ResetWords += reset;
    }

    private void False(string word)
    {
        text.text = Word_BS.currentTranslate;
        text.color = Color.green;
    }

    private void reset()
    {
        text.color = new Color(0, 0, 0, 0);
    }

    private void OnDestroy()
    {
        Variant_BS.SelectedWrongAnswer -= False;
        Word_BS.ResetWords -= reset;
    }
}
