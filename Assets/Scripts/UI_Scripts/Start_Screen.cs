using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;


public class Start_Screen : MonoBehaviour
{
    [SerializeField]
    private GameObject _startBtn;
    [SerializeField]
    private GameObject _introBackground;
    [SerializeField]
    private Button _arrowButton;
    [SerializeField]
    private Image _clipboardImage;
    [SerializeField]
    private Image _newspaper;
    [SerializeField]
    private GameObject _killer;
    [SerializeField]
    private GameObject _bgKiller;
    [SerializeField]
    private GameObject _textDialog;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;

    public int count;

    public void startGame()
    {
        count = 0;

        _startBtn.SetActive(false);
        //show player info
        _killer.SetActive(true);
        _bgKiller.SetActive(true);
        _textDialog.SetActive(true);
        /*_introBackground.SetActive(true);
        _newspaper.gameObject.SetActive(true);
        _arrowButton.gameObject.SetActive(true);*/
    }


    public void checkFinish()
    {
        typewriterUI typewriter = GameObject.Find("Introduction").GetComponent<typewriterUI>();
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
            
        } else if (count == 2)
        {
            text2.gameObject.SetActive(true);
            
        } else if (count == 3)
        {
            text3.gameObject.SetActive(true);
            _clipboardImage.gameObject.SetActive(true);
        } else if (count == 4)
        {
            text4.gameObject.SetActive(true);
            
        } else if (count == 5)
        {
            text5.gameObject.SetActive(true);
        } else if (count > 5)
        {
            defaultValues();
            _arrowButton.gameObject.SetActive(false);
            _introBackground.gameObject.SetActive(false);
            _introBackground.SetActive(false);

            //show player info
            _killer.SetActive(true);
            _bgKiller.SetActive(true);
            _textDialog.SetActive(true);
        }
    }

    private void okClick()
    {
        _textDialog.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
        }
    }

    public void defaultValues()
    {
        _newspaper.gameObject.SetActive(false);
        _clipboardImage.gameObject.SetActive(false);
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
