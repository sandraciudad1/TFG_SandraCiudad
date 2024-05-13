using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Television : MonoBehaviour
{
    [SerializeField]
    private GameObject _caras_test;
    [SerializeField]
    private GameObject _bg_explanation;
    [SerializeField]
    private Button _arrowButton_caras;
    [SerializeField]
    private Image _caras_example;
    [SerializeField]
    private Image _caras_pelo;
    [SerializeField]
    private Image _caras_cejas;
    [SerializeField]
    private Image _caras_ojos;
    [SerializeField]
    private Image _caras_boca;


    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI ex_pelo_txt;
    public TextMeshProUGUI ex_cejas_txt;
    public TextMeshProUGUI ex_ojos_txt;
    public TextMeshProUGUI ex_boca_txt;

    public int count;
    public bool next;

    public bool check;

    [SerializeField] private Button soundBtn1;
    [SerializeField] private Button soundBtn2;
    [SerializeField] private Button soundBtn3;
    [SerializeField] private Button soundBtn4;
    [SerializeField] private Button soundBtn5;
    [SerializeField] private Button soundBtn6;
    [SerializeField] private Button soundBtn7;
    [SerializeField] private TextMeshProUGUI skipText;
    [SerializeField] private TextMeshProUGUI s;

    private void Start()
    {
        count = 1;
        next = false;
    }

   

    public void startIntroduction()
    {
        _bg_explanation.SetActive(true);

        selecText();
    }


    public void checkFinish()
    {
        typewriter_caras typewriter = GameObject.Find("remoteControl").GetComponent<typewriter_caras>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            _arrowButton_caras.gameObject.SetActive(true);
            typewriter._finishWritting = false;
        }
    }


    public void Update()
    {
        if (check == true)
        {
            Caras_test caras = GameObject.Find("CarasTest").GetComponent<Caras_test>();
            if (caras != null && next == false)
            {
                //caras._canStart = true;
                caras.canStart();
            }
            check = false;
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
            text2.gameObject.SetActive(true);
            soundBtn2.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count == 3)
        {
            text3.gameObject.SetActive(true);
            _caras_example.gameObject.SetActive(true);
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
            ex_boca_txt.gameObject.SetActive(true);
            ex_cejas_txt.gameObject.SetActive(true);
            ex_ojos_txt.gameObject.SetActive(true);
            ex_pelo_txt.gameObject.SetActive(true);
            _caras_boca.gameObject.SetActive(true);
            _caras_cejas.gameObject.SetActive(true);
            _caras_ojos.gameObject.SetActive(true);
            _caras_pelo.gameObject.SetActive(true);
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
        else if (count == 7)
        {
            text7.gameObject.SetActive(true);
            soundBtn7.gameObject.SetActive(true);
            skipText.gameObject.SetActive(true);
            s.gameObject.SetActive(true);
        }
        else if (count > 7)
        {
            defaultValues();
            _arrowButton_caras.gameObject.SetActive(false);
            _bg_explanation.SetActive(false);
            _caras_test.SetActive(true);

            check = true;
            Update();
        }
    }

    public void defaultValues()
    {
        _arrowButton_caras.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        text6.gameObject.SetActive(false);
        text7.gameObject.SetActive(false);
        ex_boca_txt.gameObject.SetActive(false);
        ex_cejas_txt.gameObject.SetActive(false);
        ex_ojos_txt.gameObject.SetActive(false);
        ex_pelo_txt.gameObject.SetActive(false);
        _caras_boca.gameObject.SetActive(false);
        _caras_cejas.gameObject.SetActive(false);
        _caras_ojos.gameObject.SetActive(false);
        _caras_pelo.gameObject.SetActive(false);
        _caras_example.gameObject.SetActive(false);
        soundBtn1.gameObject.SetActive(false);
        soundBtn2.gameObject.SetActive(false);
        soundBtn3.gameObject.SetActive(false);
        soundBtn4.gameObject.SetActive(false);
        soundBtn5.gameObject.SetActive(false);
        soundBtn6.gameObject.SetActive(false);
        soundBtn7.gameObject.SetActive(false);
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
