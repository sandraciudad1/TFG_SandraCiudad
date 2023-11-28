using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class anillas : MonoBehaviour
{
    [SerializeField]
    private GameObject _anillas_test;
    [SerializeField]
    private Button _arrowButton_anillas;

    [SerializeField]
    private Image _red_arrow;
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
        typewriter_anillas typewriter = GameObject.Find("Anillas").GetComponent<typewriter_anillas>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            _arrowButton_anillas.gameObject.SetActive(true);
            typewriter._finishWritting = false;
        }
    }

    public void Update()
    {


        if (init_animation == true)
        {
            animationController_anillas anim = GameObject.Find("anillas_structure").GetComponent<animationController_anillas>();
            if (anim != null)
            {
                anim.init_anim = true;
            }
        }



        if (finish == true && next == false)
        {
            Debug.Log("empezando el test de anillas...");
            /*Nback_test nback = GameObject.Find("NbackTest").GetComponent<Nback_test>();
            if (nback != null && finish == true)
            {
                nback.can_start = true;
                nback.nextTest();
            }*/
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
            _red_arrow.gameObject.SetActive(true);
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
            _arrowButton_anillas.gameObject.SetActive(false);
            _anillas_test.SetActive(true);

            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Anillas/Results.txt");
            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Anillas/Time.txt");


            init_animation = true;
            Update();
        }
    }

    public void defaultValues()
    {
        _arrowButton_anillas.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        text4.gameObject.SetActive(false);
        text5.gameObject.SetActive(false);
        text6.gameObject.SetActive(false);
        _red_arrow.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();
    }
}
