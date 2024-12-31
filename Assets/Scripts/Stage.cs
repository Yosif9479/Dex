using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int id;
    public void SetStage()
    {
        Informations.stageId = id;
    }
}
