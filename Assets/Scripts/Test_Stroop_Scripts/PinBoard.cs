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

    

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    public void Update()
    {

       
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
            stroop_example_1.gameObject.SetActive(true);
            stroop_example_2.gameObject.SetActive(true);
            stroop_example_3.gameObject.SetActive(true);
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
            _pb_clean.gameObject.SetActive(false);
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
        stroop_example_1.gameObject.SetActive(false);
        stroop_example_2.gameObject.SetActive(false);
        stroop_example_3.gameObject.SetActive(false);
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
