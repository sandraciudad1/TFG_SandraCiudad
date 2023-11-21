using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class card_deck : MonoBehaviour
{
    [SerializeField]
    private GameObject _caras_test;
    [SerializeField]
    private GameObject _bg_explanation;
    [SerializeField]
    private Button _arrowButton_cards;


    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    public int count;

    private void Start()
    {
        count = 1;
    }


    public void startIntroduction()
    {
        //_bg_explanation.SetActive(true);

        selecText();
    }


    public void checkFinish()
    {
        typewriter_nback typewriter = GameObject.Find("card_deck").GetComponent<typewriter_nback>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            _arrowButton_cards.gameObject.SetActive(true);
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
        else if (count > 6)
        {
            defaultValues();
            _arrowButton_cards.gameObject.SetActive(false);
            _bg_explanation.SetActive(false);
            _caras_test.SetActive(true);

            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Nback/Results.txt");
            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Nback/Time.txt");

            Nback_test nback = GameObject.Find("NbackTest").GetComponent<Nback_test>();
            if (nback != null)
            {
                nback.nextTest();
            }
        }
    }

    public void defaultValues()
    {
        _arrowButton_cards.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        text6.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();
    }
}

