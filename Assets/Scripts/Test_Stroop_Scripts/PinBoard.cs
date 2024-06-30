using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class PinBoard : MonoBehaviour
{
    [SerializeField]
    private Image _pb_clean;
    [SerializeField]
    private Button _arrowButton;
    [SerializeField]
    private GameObject _stroop_test;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI stroop_example_1;
    public TextMeshProUGUI stroop_example_2;
    public TextMeshProUGUI stroop_example_3;

    public int count;
    public bool skip;

    Vector3 final_pos = new Vector3(13.358f, 1.31f, -9.092f);

    [SerializeField] private Button soundBtn1;
    [SerializeField] private Button soundBtn2;
    [SerializeField] private Button soundBtn3;
    [SerializeField] private Button soundBtn4;
    [SerializeField] private Button soundBtn5;
    [SerializeField] private Button soundBtn6;
    [SerializeField] private TextMeshProUGUI skipText;
    [SerializeField] private TextMeshProUGUI s;


    public void Start()
    {
        count = 1;
        skip = false;
    }


    public void startIntroduction()
    {
        float step = Time.deltaTime;
        _pb_clean.transform.position = Vector3.MoveTowards(_pb_clean.transform.position, final_pos, step);
        _pb_clean.gameObject.SetActive(true);
        selecText();
    }

    public void checkFinish()
    {
        typewriter_stroop typewriter = GameObject.Find("pinboard").GetComponent<typewriter_stroop>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            _arrowButton.gameObject.SetActive(true);
            typewriter._finishWritting = false;
        }
    }


    public void selecText()
    {
        if (count == 1)
        {
            text1.gameObject.SetActive(true);
            soundBtn1.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);

        }
        else if (count == 2)
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
            soundBtn2.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count == 3)
        {
            text3.gameObject.SetActive(true);
            stroop_example_1.gameObject.SetActive(true);
            stroop_example_2.gameObject.SetActive(true);
            stroop_example_3.gameObject.SetActive(true);
            soundBtn3.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count == 4)
        {
            text4.gameObject.SetActive(true);
            soundBtn4.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count == 5)
        {
            text5.gameObject.SetActive(true);
            soundBtn5.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count == 6)
        {
            text6.gameObject.SetActive(true);
            soundBtn6.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count > 6)
        {
            defaultValues();
            _arrowButton.gameObject.SetActive(false);
            _pb_clean.gameObject.SetActive(false);
            _stroop_test.SetActive(true);

            Stroop_test stroop_test = GameObject.Find("StroopTest").GetComponent<Stroop_test>();
            if (stroop_test != null)
            {
                stroop_test.canStart();
            }
        }
    }

    public void defaultValues()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        text6.gameObject.SetActive(false);
        stroop_example_1.gameObject.SetActive(false);
        stroop_example_2.gameObject.SetActive(false);
        stroop_example_3.gameObject.SetActive(false);
        _arrowButton.gameObject.SetActive(false);
        skip = false;
        soundBtn1.gameObject.SetActive(false);
        soundBtn2.gameObject.SetActive(false);
        soundBtn3.gameObject.SetActive(false);
        soundBtn4.gameObject.SetActive(false);
        soundBtn5.gameObject.SetActive(false);
        soundBtn6.gameObject.SetActive(false);
        skipText.gameObject.SetActive(false);
        s.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();

    }
}
