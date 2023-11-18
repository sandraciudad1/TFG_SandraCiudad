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

    private void Start()
    {
        count = 1;
        Debug.Log("count en start : " + count);
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


    public void selecText()
    {
        if (count == 1)
        {
            Debug.Log("en el count 1 " + count);
            text1.gameObject.SetActive(true);

        }
        else if (count == 2)
        {
            Debug.Log("en el count 2 " + count);
            text2.gameObject.SetActive(true);

        }
        else if (count == 3)
        {
            Debug.Log("en el count 3 " + count);
            text3.gameObject.SetActive(true);
            _caras_example.gameObject.SetActive(true);
        }
        else if (count == 4)
        {
            Debug.Log("en el count 4 " + count);
            text4.gameObject.SetActive(true);

        }
        else if (count == 5)
        {
            Debug.Log("en el count 5 " + count);
            text5.gameObject.SetActive(true);
            ex_boca_txt.gameObject.SetActive(true);
            ex_cejas_txt.gameObject.SetActive(true);
            ex_ojos_txt.gameObject.SetActive(true);
            ex_pelo_txt.gameObject.SetActive(true);
            _caras_boca.gameObject.SetActive(true);
            _caras_cejas.gameObject.SetActive(true);
            _caras_ojos.gameObject.SetActive(true);
            _caras_pelo.gameObject.SetActive(true);
        }
        else if (count == 6)
        {
            Debug.Log("en el count 6 " + count);
            text6.gameObject.SetActive(true);
        }
        else if (count == 7)
        {
            Debug.Log("en el count 7 " + count);
            text7.gameObject.SetActive(true);
        }
        else if (count > 7)
        {
            Debug.Log("en el count > 8");
            defaultValues();
            _arrowButton_caras.gameObject.SetActive(false);
            _bg_explanation.SetActive(false);
            _caras_test.SetActive(true);

            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Results.txt");
            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Time.txt");

            Caras_test caras = GameObject.Find("CarasTest").GetComponent<Caras_test>();
            if (caras != null)
            {
                Debug.Log("ha encontrado el caras test");
                caras.nextTest();
            }
        }
    }

    public void defaultValues()
    {
        Debug.Log("en el default values " + count);
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
    }

    public void nextText()
    {
        Debug.Log("en el nextText " + count);
        defaultValues();
        count += 1;
        selecText();
    }
}
