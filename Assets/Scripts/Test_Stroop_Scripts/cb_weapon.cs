using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class cb_weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _stroop_test;
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _bg_explanation;

    [SerializeField]
    //private GameObject _introBackground;
    private GameObject _background_tests;

    [SerializeField]
    private Button _arrowButton;
    [SerializeField]
    private Image _stroop_example;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;

    public int count;
    public bool _explanation = true;
    public bool _cb_weapon = true;

    private void Start()
    {
        count = 1;
    }

    //Check if cb_weapon us colliding with player
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    _weapon.SetActive(false);
                    player._doingTest = true;

                    _bg_explanation.SetActive(true);
                    selecText();
                }
            }

        }
    }

    public void checkFinish()
    {
        typewriter_stroop typewriter = GameObject.Find("test_intros").GetComponent<typewriter_stroop>();
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
            _stroop_test.SetActive(true);

            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results.txt");
            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Time.txt");

            Stroop_test stroop_test = GameObject.Find("StroopTest").GetComponent<Stroop_test>();
            if (stroop_test != null)
            {
                stroop_test.nextTest();
            }
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
        text6.gameObject.SetActive(false);
    }

    public void nextText()
    {
        defaultValues();
        count += 1;
        selecText();

    }
}
