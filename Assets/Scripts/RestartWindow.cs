using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartWindow : MonoBehaviour
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    protected void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ToggleActive(bool playAnimation)
    {
        if (gameObject.activeInHierarchy)
        {
            _animation.Play("Finish");
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
