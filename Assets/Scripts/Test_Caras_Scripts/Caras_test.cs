using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using System.Threading;

public class Caras_test : MonoBehaviour
{
    [SerializeField]
    public GameObject _canvasCaras;
    [SerializeField]
    public GameObject _background;
    [SerializeField]
    private Button finish_btn_caras;
    [SerializeField]
    private Image bar_fill;

    [SerializeField]
    private Sprite caras11;
    [SerializeField]
    private Sprite caras12; 
    [SerializeField]
    private Sprite caras13;
    [SerializeField]
    private Sprite caras21;
    [SerializeField]
    private Sprite caras22;
    [SerializeField]
    private Sprite caras23;
    [SerializeField]
    private Sprite caras31;
    [SerializeField]
    private Sprite caras32;
    [SerializeField]
    private Sprite caras33;
    [SerializeField]
    private Sprite caras41;
    [SerializeField]
    private Sprite caras42;
    [SerializeField]
    private Sprite caras43;
    [SerializeField]
    private Sprite caras51;
    [SerializeField]
    private Sprite caras52;
    [SerializeField]
    private Sprite caras53;
    [SerializeField]
    private Sprite caras61;
    [SerializeField]
    private Sprite caras62;
    [SerializeField]
    private Sprite caras63;


    [SerializeField]
    private float timerTime;
    public int min, seg = 15, intervalo = 1;
    public float nextTime = 0;

    public Button img1;
    public Button img2;
    public Button img3;
    
   
    public Image red_cross1;
    public Image red_cross2;
    public Image red_cross3;

    private int count;
    private DateTime tiempo1 = DateTime.Now, tiempo2;

    public bool allowed;
    public bool im1, im2, im3, im4;
    public bool _canStart;

    public string value;
    public bool pressed;
    public bool start_timer;
    public string text_result;
    public float stop;

    [SerializeField] TextMeshProUGUI timer_text;
    public float remaining_time;

    //private float startTime;
    //private float stopTime;
    //private float timer_Time;
    public bool isrunning;
    public bool finish;
    public bool showCard;
    public int write = 0;
    private int minutes;
    private int seconds;

    public void Start()
    {
        //_canStart = false;
        isrunning = false;
        count = 1;
        pressed = false;
        start_timer = false;
        //nextTest();
        finish = false;

    }


    void Update()
    {
        if (showCard == true && finish == false)
        {
            showCard_caras();
            finish = true;
        }

        if (count > 6)
        {
            img1.gameObject.SetActive(false);
            img2.gameObject.SetActive(false);
            img3.gameObject.SetActive(false);
            red_cross1.gameObject.SetActive(false);
            red_cross2.gameObject.SetActive(false);
            red_cross3.gameObject.SetActive(false);
            finish_btn_caras.gameObject.SetActive(true);
            timer_text.gameObject.SetActive(false);
            //finish = true;
           

        }
        else if (count <= 6 && _canStart == true)
        {
            remaining_time = Math.Abs(remaining_time);
            float timer = Math.Abs(Time.deltaTime);
            remaining_time -= timer;
            
            minutes = Mathf.FloorToInt(remaining_time / 60);
            seconds = Mathf.FloorToInt(remaining_time % 60);
            minutes = Math.Abs(minutes);
            seconds = Math.Abs(seconds);
            timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (pressed == true)
            {
                img1.interactable = false;
                img2.interactable = false;
                img3.interactable = false;
            }

            if(minutes == 0 && seconds == 0)
            {
                nextTest();
            }
        }
    }
       

    public void finishCaras()
    {
        _canvasCaras.SetActive(false);
        animationController anim = GameObject.Find("RemoteControl_").GetComponent<animationController>();
        if (anim != null)
        {
            anim.start_turnOff_tv = true;
        }



    }

    public void showCard_caras()
    {
        Debug.Log("mostrando carta...");
        //coroutine con tiempo de apagado de pantalla
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if (show != null)
        {
            show.show_reason_card();
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.reasonCollected();
        }

        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });
    }

    public void defaultValues()
    {
        img1.interactable = true;
        img2.interactable = true;
        img3.interactable = true;
        red_cross1.gameObject.SetActive(false);
        red_cross2.gameObject.SetActive(false);
        red_cross3.gameObject.SetActive(false);
        remaining_time = 6;
        
        pressed = false;
        value = "";
    }


    public void saveTestsResults()
    {
        
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Results.txt";
        if (count > 0)
        {
            text_result = "ronda " + count + ": " + value;
            File.AppendAllLines(path, new String[] { text_result });
            
        }
    }

    public void UpdateProgress()
    {
        float amount = (float)count / 6;
        bar_fill.fillAmount = amount;
    }


    public void firstClicked()
    {
        red_cross1.gameObject.SetActive(true);
        value = "Izquierda";
        saveTestsResults();
        pressed = true;
    }

    public void secondClicked()
    {
        red_cross2.gameObject.SetActive(true);
        value = "Centro";
        saveTestsResults();
        pressed = true;
    }

    public void thirdClicked()
    {
        red_cross3.gameObject.SetActive(true);
        value = "Derecha";
        saveTestsResults();
        pressed = true;
    }


    public void testOptions()
    {
        if (count == 1)
        {
            img1.image.sprite = caras11;
            img2.image.sprite = caras12;
            img3.image.sprite = caras13;

        } else if (count == 2)
        {
            img1.image.sprite = caras21;
            img2.image.sprite = caras22;
            img3.image.sprite = caras23;
        } else if (count == 3)
        {
            img1.image.sprite = caras31;
            img2.image.sprite = caras32;
            img3.image.sprite = caras33;
        } else if (count == 4)
        {
            img1.image.sprite = caras41;
            img2.image.sprite = caras42;
            img3.image.sprite = caras43;
        } else if (count == 5)
        {
            img1.image.sprite = caras51;
            img2.image.sprite = caras52;
            img3.image.sprite = caras53;
        } else if (count == 6)
        {
            img1.image.sprite = caras61;
            img2.image.sprite = caras62;
            img3.image.sprite = caras63;
        }


    }


    public void nextTest()
    {
        UpdateProgress();
        count = count + 1;
        defaultValues();
        testOptions();
    }


}
