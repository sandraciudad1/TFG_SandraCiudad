using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Story : MonoBehaviour
{
    [SerializeField]
    private Button _arrowButton_story;
    [SerializeField]
    private GameObject giovanni_dialog;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;
    public TextMeshProUGUI text9;
    public TextMeshProUGUI text10;
    public TextMeshProUGUI text11;
    public TextMeshProUGUI correct;
    public TextMeshProUGUI incorrect;

    public int count;
    public bool solution;

    void Start()
    {
        count = 1;
        
    }

    public void Update()
    {
        
        
    }

    public void startIntroduction()
    {
        selecText();
        giovanni_dialog.SetActive(true);
        //nextText();
    }


    public void checkFinish()
    {
        typewriter_story typewriter = GameObject.Find("story").GetComponent<typewriter_story>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            _arrowButton_story.gameObject.SetActive(true);
            typewriter._finishWritting = false;
        }
    }


    public void selecText()
    {
        if (count == 1)
        {
            text1.gameObject.SetActive(true);
        }
        else if (count == 2)
        {
            text2.gameObject.SetActive(true);
        }
        else if (count == 3)
        {
            text3.gameObject.SetActive(true);
        }
        else if (count == 4)
        {
            text4.gameObject.SetActive(true);
        }
        else if (count == 5)
        {
            text5.gameObject.SetActive(true);
        }
        else if (count == 6)
        {
            text6.gameObject.SetActive(true);
        }
        if (count == 7)
        {
            text7.gameObject.SetActive(true);
        }
        else if (count == 8)
        {
            text8.gameObject.SetActive(true);
        }
        else if (count == 9)
        {
            text9.gameObject.SetActive(true);
        }
        else if (count == 10)
        {
            text10.gameObject.SetActive(true);
        }
        else if (count == 11)
        {
            text11.gameObject.SetActive(true);
        }
        else if (count == 12)
        {
            animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
            if (anim != null)
            {
                if (anim.solution == true)
                {
                    correct.gameObject.SetActive(true);
                    anim.correct_anim = true;
                }
                else if (anim.solution == false)
                {
                    incorrect.gameObject.SetActive(true);
                    anim.incorrect_anim = true;
                }
            }
            
        }
        else if (count > 12)
        {
            defaultValues();
            _arrowButton_story.gameObject.SetActive(false);
            giovanni_dialog.SetActive(false);
        }
    }



    public void defaultValues()
    {
        _arrowButton_story.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        text6.gameObject.SetActive(false);
        text7.gameObject.SetActive(false);
        text8.gameObject.SetActive(false);
        text9.gameObject.SetActive(false);
        text10.gameObject.SetActive(false);
        text11.gameObject.SetActive(false);
        correct.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(false);
    }

    public void nextText()
    {
        text1.gameObject.SetActive(false);
        defaultValues();
        count += 1;
        selecText();
    }
}
