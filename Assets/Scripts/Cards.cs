using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public int id;
    public static int focus;
    public string termin, translate;
    public Text Word, learnedTEXT, rightNumT, leftNumT;
    public string grabing;
    public Image learnedIMG;
    [HideInInspector] public Camera cam;
    public float maxRight, maxLeft;
    private Animation anim;
    public GameObject finishMenu;
    public Canvas canvas;
    private bool right;
    public static int leftNum, rightNum;

    private void Awake()
    {
        leftNum = 0;
        rightNum = 0;
    }

    private void Start()
    {
        Word = GetComponentInChildren<Text>();
        anim = GetComponent<Animation>();
        termin = Informations.currentModule[id].Replace("\"", "");
        if (Informations.tjMode)
        {
            translate = Informations.currentModule[id + (Informations.amountOfTerminsInModule * 2) + 2].Replace("\"", "");
        }
        else
        {
            translate = Informations.currentModule[id + Informations.amountOfTerminsInModule + 1].Replace("\"", "");
        }
        Word.text = termin;
        focus = 0;
        RandomRotate();
    }

    private void Update()
    {
        if (focus == id)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            Word.color = new Color(Word.color.r, Word.color.g, Word.color.b, 1);
            if (grabing == "grab")
            {
                if (anim.isPlaying == false)
                {
                    transform.position = new Vector2 (cam.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
                }
            }
            if (grabing == "endGrab")
            {
                if (transform.position.x > maxRight && transform.position.x < 10)
                {
                    transform.position = new Vector2(transform.position.x + 0.1f, 0);
                }
                else if (transform.position.x < maxLeft && transform.position.x > -10)
                {
                    transform.position = new Vector2(transform.position.x - 0.1f, 0);
                }
                else if (transform.position.x > maxLeft && transform.position.x < maxRight)
                {
                    if (anim.isPlaying)
                    {
                        anim.Stop();
                    }
                    transform.position = new Vector2(0, 0);
                    learnedIMG.color = new Color(1, 1, 1, 0);
                }
                if (transform.position.x > 5 || transform.position.x < -5)
                {
                    focus++;
                    Word.text = termin;
                    if (transform.position.x > 0)
                    {
                        right = true;
                        rightNum++;
                    }
                    else if (transform.position.x < 0)
                    {
                        right = false;
                        leftNum++;
                    }
                    grabing = null;
                }
            }
        }
        if (id - focus >= 3)
        {
            GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0);
        }
        else
        {
            GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 1);
        }
        if (ReturnAndRestart.rest == "returnLast")
        {
            if (focus > 0)
            {
                if (focus - 1 == id)
                {
                    focus--;
                    transform.position = new Vector2(0, 0);
                    ReturnAndRestart.rest = null;
                    learnedIMG.color = new Color(1, 1, 1, 0);
                    if (right)
                    {
                        rightNum--;
                    }
                    else
                    {
                        leftNum--;
                    }
                }
            }
            else
            {
                ReturnAndRestart.rest = null;
            }
        }
        else if (ReturnAndRestart.rest == "restart")
        {
            if (focus - 1 == id)
            {
                focus--;
                transform.position = new Vector2(0, 0);
                learnedIMG.color = new Color(1, 1, 1, 0);
            }
            if (focus == 0)
            {
                ReturnAndRestart.rest = null;
                rightNum = 0;
                leftNum = 0;
            }
        }
        rightNumT.text = System.Convert.ToString(rightNum);
        leftNumT.text = System.Convert.ToString(leftNum);
        CheckColor();
    }

    public void Grab(string opt)
    {
        grabing = opt;
    }

    public void CheckColor()
    {
        if (transform.position.x > 0)
        {
            learnedIMG.color = new Color(Color.green.r, Color.green.g, Color.green.b, 1 / transform.position.x);
            learnedTEXT.text = "Изучено";
        }
        else if (transform.position.x < 0)
        {
            learnedIMG.color = new Color(Color.red.r, Color.red.g, Color.red.b, 1 / Mathf.Abs(transform.position.x));
            learnedTEXT.text = "Не изучено";
        }
    }

    public void Rotate()
    {
        if (focus == id)
        {
            anim.Play();
        }
    }

    public void ChangeWord()
    {
        if (Word.text == termin)
        {
            Word.text = translate;
        }
        else if (Word.text == translate)
        {
            Word.text = termin;
        }
    }

    public void RandomRotate()
    {
        if (id % 2 == 0)
        {
            transform.rotation = new Quaternion(0, 0, 15, 360);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, -15, 360);
        }
    }
}