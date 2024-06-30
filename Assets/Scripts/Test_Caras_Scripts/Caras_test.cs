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
    [SerializeField] public GameObject _canvasCaras;
    [SerializeField] public GameObject _background;
    [SerializeField] private GameObject finish_btn_caras;
    [SerializeField] private Image bar_fill;

    [SerializeField] private Sprite caras11;
    [SerializeField] private Sprite caras12; 
    [SerializeField] private Sprite caras13;
    [SerializeField] private Sprite caras21;
    [SerializeField] private Sprite caras22;
    [SerializeField] private Sprite caras23;
    [SerializeField] private Sprite caras31;
    [SerializeField] private Sprite caras32;
    [SerializeField] private Sprite caras33;
    [SerializeField] private Sprite caras41;
    [SerializeField] private Sprite caras42;
    [SerializeField] private Sprite caras43;
    [SerializeField] private Sprite caras51;
    [SerializeField] private Sprite caras52;
    [SerializeField] private Sprite caras53;
    [SerializeField] private Sprite caras61;
    [SerializeField] private Sprite caras62;
    [SerializeField] private Sprite caras63;
    [SerializeField] private Sprite caras71;
    [SerializeField] private Sprite caras72;
    [SerializeField] private Sprite caras73;
    [SerializeField] private Sprite caras81;
    [SerializeField] private Sprite caras82;
    [SerializeField] private Sprite caras83;
    [SerializeField] private Sprite caras91;
    [SerializeField] private Sprite caras92;
    [SerializeField] private Sprite caras93;
    [SerializeField] private Sprite caras101;
    [SerializeField] private Sprite caras102;
    [SerializeField] private Sprite caras103;


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
    public Image tick1;
    public Image tick2;
    public Image tick3;
    [SerializeField] private GameObject pressed1;
    [SerializeField] private GameObject pressed2;
    [SerializeField] private GameObject pressed3;

    private int count;
    public DateTime tiempo1, tiempo2;

    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;

    public bool allowed;
    public bool im1, im2, im3, im4;
    public bool _canStart;

    public string value;
    public bool start_timer;
    public string text_result="";
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

    public bool time;
    public string actual_date;
    private bool saveTime = false;
    private int clickCounter=1;
    private bool clickCara = false;
    private bool izq = false, cen=false, der=false;
    private bool saveResults = false;

    [SerializeField] GameObject naxtRoundCaras;

    public void Start()
    {
        //_canStart = false;
        isrunning = false;
        count = 1;
        start_timer = false;
        //nextTest();
        finish = false;
        time = false;
        remaining_time = 31;
        //canStart();
        tiempo1 = DateTime.Now;
        month = DateTime.Now.ToString("MM");
        day = DateTime.Now.ToString("dd");
        year = DateTime.Now.ToString("yyyy");
        hour = DateTime.Now.ToString("HH");
        _min = DateTime.Now.ToString("mm");
        actual_date = day + "_" + month + "_" + year + "__" + hour + "_" + _min;

    }

    public void canStart()
    {
        

        _canStart = true;
        remaining_time = 31;
        nextTest();
    }

    public void Update()
    {
        
        if (showCard == true && finish == false)
        {
            showCard_caras();
            finish = true;
        }

        if (_canStart == true)
        {
            remaining_time -= Time.deltaTime;
            remaining_time = Mathf.Max(0f, remaining_time);

            int minutes = Mathf.FloorToInt(remaining_time / 60);
            int seconds = Mathf.FloorToInt(remaining_time % 60);
            timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }


        if (img1.interactable == false && clickCounter <= 10 && clickCara == false)
        {
            if (pressed3.activeInHierarchy)
            {
                value = "Derecha";
            }
            else if (pressed2.activeInHierarchy)
            {
                value = "Centro";
            }
            else if (pressed1.activeInHierarchy)
            {
                value = "Izquierda";
            }

            showCorrectOption(value);
            text_result += "ronda " + clickCounter + ": " + value + "\n";
            clickCounter++;
            clickCara = true;
        }

        if (clickCounter > 10 && saveResults==false)
        {
            seconds = 0;
            naxtRoundCaras.gameObject.SetActive(false);
            img1.gameObject.SetActive(false);
            img2.gameObject.SetActive(false);
            img3.gameObject.SetActive(false);
            finish_btn_caras.gameObject.SetActive(true);
            timer_text.gameObject.SetActive(false);
            saveTimeResults();
            saveTestsResults();
            saveResults = true;
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

    }

    public void defaultValues()
    {
        img1.interactable = true;
        img2.interactable = true;
        img3.interactable = true;
        red_cross1.gameObject.SetActive(false);
        red_cross2.gameObject.SetActive(false);
        red_cross3.gameObject.SetActive(false);
        tick1.gameObject.SetActive(false);
        tick2.gameObject.SetActive(false);
        tick3.gameObject.SetActive(false);
        remaining_time = 31;
        pressed1.SetActive(false);
        pressed2.SetActive(false);
        pressed3.SetActive(false);
        clickCara = false;
        //value = "";
    }

    public void saveTimeResults()
    {
        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Time_" + actual_date + ".txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        
        File.AppendAllLines(path, new String[] { text });
    }

    public void saveTestsResults()
    {
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Results_" + actual_date + ".txt";
        if (count > 0)
        {
            
            File.AppendAllLines(path, new String[] { text_result });
        }
    }

    public void UpdateProgress()
    {
        float amount = (float)count / 10;
        bar_fill.fillAmount = amount;
    }


    public void firstClicked()
    {
        pressed1.SetActive(true);
        notInteractable();
    }

    public void secondClicked()
    {
        pressed2.SetActive(true);
        notInteractable(); 
    }

    public void thirdClicked()
    {
        pressed3.SetActive(true);
        notInteractable();
    }

    public void notInteractable()
    {
        img1.interactable = false;
        img2.interactable = false;
        img3.interactable = false;
    }

    void showCorrectOption(String value)
    {
        if (clickCounter == 1 || clickCounter == 5 || clickCounter == 6 || clickCounter == 9) { correctDer(value); }
        else if (clickCounter == 2 || clickCounter == 3 || clickCounter == 4 || clickCounter == 8) { correctCen(value); }
        else if (clickCounter == 7 || clickCounter == 10) { correctIzq(value); }
    }

    public void correctDer(String value)
    {
        tick3.gameObject.SetActive(true);
        if (value.Equals("Centro"))
        {
            red_cross2.gameObject.SetActive(true);
        }
        else if (value.Equals("Izquierda"))
        {
            red_cross1.gameObject.SetActive(true);
        }
    }

    public void correctCen(String value)
    {
        tick2.gameObject.SetActive(true);
        if (value.Equals("Derecha"))
        {
            red_cross3.gameObject.SetActive(true);
        }
        else if (value.Equals("Izquierda"))
        {
            red_cross1.gameObject.SetActive(true);
        }
    }

    public void correctIzq(String value)
    {
        tick1.gameObject.SetActive(true);
        if (value.Equals("Derecha"))
        {
            red_cross3.gameObject.SetActive(true);
        }
        else if (value.Equals("Centro"))
        {
            red_cross2.gameObject.SetActive(true);
        }
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
        else if (count == 7)
        {
            img1.image.sprite = caras71;
            img2.image.sprite = caras72;
            img3.image.sprite = caras73;
        }
        else if (count == 8)
        {
            img1.image.sprite = caras81;
            img2.image.sprite = caras82;
            img3.image.sprite = caras83;
        }
        else if (count == 9)
        {
            img1.image.sprite = caras91;
            img2.image.sprite = caras92;
            img3.image.sprite = caras93;
        }
        else if (count == 10)
        {
            img1.image.sprite = caras101;
            img2.image.sprite = caras102;
            img3.image.sprite = caras103;
        }


    }
    

    public void nextTest()
    {
        UpdateProgress();
        count = count + 1;
        testOptions();
        //saveTestsResults(clickCounter, value);
        defaultValues();
    }


}
