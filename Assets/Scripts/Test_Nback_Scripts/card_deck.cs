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

    [SerializeField]
    private Image _example;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    public int count;
    public bool init_animation;
    public bool finish;
    public bool next;

    private void Start()
    {
        count = 1;
        init_animation = false;
        finish = false;
        next = false;
    }


    public void startIntroduction()
    {
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

    public void Update()
    {
        

        if (init_animation==true)
        {
            animationController_nback anim = GameObject.Find("CardFan_Hearts_").GetComponent<animationController_nback>();
            if (anim != null)
            {
                anim.init_anim = true;
            }
        }
      
        

        if(finish == true && next == false)
        {
            Nback_test nback = GameObject.Find("NbackTest").GetComponent<Nback_test>();
            if (nback != null && finish == true)
            {
                nback.can_start = true;
                nback.nextTest();
            }
            next = true;
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
            _example.gameObject.SetActive(true);
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
          
            init_animation = true;
            Update();
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
        _example.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();
    }
}

