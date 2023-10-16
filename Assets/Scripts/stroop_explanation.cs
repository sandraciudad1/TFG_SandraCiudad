using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class stroop_explanation : MonoBehaviour
{
    [SerializeField]
    //private GameObject _introBackground;
    private GameObject _background_tests;

    [SerializeField]
    private Button _arrowButton;
    [SerializeField]
    //private Image _clipboardImage;
    private Image _stroop_example;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    public int count;
    public bool _explanation = true;


    public void checkFinish()
    {
        typewriterUI typewriter2 = GameObject.Find("test_intros").GetComponent<typewriterUI>();
        if (typewriter2 != null && typewriter2._finishWritting == true)
        {
            _arrowButton.gameObject.SetActive(true);
            typewriter2._finishWritting = false;
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
            _stroop_example.gameObject.SetActive(true);
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
        else if (count > 6)
        {
            defaultValues();
            _arrowButton.gameObject.SetActive(false);
            _background_tests.SetActive(false);
            _explanation = false;
        }
    }

    public void defaultValues()
    {
        _stroop_example.gameObject.SetActive(false);
        _arrowButton.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();
    }
}
