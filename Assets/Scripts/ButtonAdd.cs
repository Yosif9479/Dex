using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAdd : MonoBehaviour
{
    public GameObject CreatorPanel, Blocker, canvas;
    public static bool CreatorIsOpen = false;
    public void Start()
    {
        CreatorPanel = GameObject.FindWithTag("PanelCreator");
        canvas = GameObject.FindWithTag("Main Canvas");
    }
    public void ToggleCreatorPanel()
    {
        if (ButtonAdd.CreatorIsOpen == false)
        {
            CreatorPanel.GetComponent<Animation>().Play("PanelCreator");
            ButtonAdd.CreatorIsOpen = true;
            Instantiate(Blocker, canvas.transform);
        }
        else if (ButtonAdd.CreatorIsOpen == true)
        {
            CreatorPanel.GetComponent<Animation>().Play("PanelCreator1");
            ButtonAdd.CreatorIsOpen = false;
            Destroy(GameObject.FindGameObjectWithTag("Blocker"));
        }
    }
}
