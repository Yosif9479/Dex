using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animation _animation;
    private string targetScene;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    public static void CHS(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ChangeScene(string scene)
    {
        _animation.Play("Open");
        targetScene = scene;
    }

    protected void LoadScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
