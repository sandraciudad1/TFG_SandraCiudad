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
    private Image _newspaper;

    public GameObject _killer;
    public GameObject _bgKiller;
    public GameObject _textDialog;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;

    public GameObject _info_btn;
    public GameObject _info_msg;

    public int count;
    public bool init_animation;
    public bool show_info;

    public void startGame()
    {
        count = 0;
        init_animation = false;

        _startBtn.SetActive(false);
        _info_btn.SetActive(false);
        _info_msg.SetActive(false);

        //show player info
        /*_killer.SetActive(true);
        _bgKiller.SetActive(true);
        _textDialog.SetActive(true);
        _introBackground.SetActive(true);
        _newspaper.gameObject.SetActive(true);
        _arrowButton.gameObject.SetActive(true);*/
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
            player._doingTest = false;
        }

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

            init_animation = true;
            animationEffects animation = GameObject.Find("Start_Screen").GetComponent<animationEffects>();
            if (animation != null)
            {
                animation.init_player_movement = true;
                animation.Update();
            }
        }
    }

    public void Update()
    {
        animationEffects animation = GameObject.Find("Start_Screen").GetComponent<animationEffects>();
        if (animation != null)
        {
            if(animation.finish_introduction == true)
            {
                _killer.SetActive(true);
                _bgKiller.SetActive(true);
                _info_btn.gameObject.SetActive(false);
            }
            
        }
    }

    public void info_btn_click()
    {
        animationEffects animation = GameObject.Find("Start_Screen").GetComponent<animationEffects>();
        if (animation != null)
        {
            animation.finish_introduction = true;
        }
        
        _info_btn.gameObject.SetActive(false);
        _info_msg.gameObject.SetActive(true);
    }

    public void info_msg_click()
    {
        _info_msg.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
        }
    }

    /*public void okClick()
    {
        _textDialog.gameObject.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
        }
    }*/

    public void defaultValues()
    {
        _newspaper.gameObject.SetActive(false);
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
