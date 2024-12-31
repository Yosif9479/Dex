using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLoader : MonoBehaviour
{

    public GameObject me;
    public Animator animator;
    public float Time;
    public string option;
    public string scene;
    public InputField NameOfCourse;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start Menu"))
        {
            StartCoroutine(StartMenu());
        }
    }

    public IEnumerator StartMenu()
    {
        yield return new WaitForSeconds(2);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("NewMenu");
    }

    public IEnumerator changeScene(string targetScene)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(0.25f);
        ChangeScene(targetScene);
    }

    public void SceneChange(string targetScene)
    {
        StartCoroutine(changeScene(targetScene));
    }

    public void ChangeScene(string targetScene)
    {
        SceneChanger.CHS(targetScene);
    }

}
