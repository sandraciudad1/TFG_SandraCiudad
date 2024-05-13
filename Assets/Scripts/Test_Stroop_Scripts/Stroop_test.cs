using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Stroop_test : MonoBehaviour
{
    [SerializeField]
    public GameObject _canvasStroop;
    [SerializeField]
    public Image _background;
    [SerializeField]
    private Button finish_btn;
    [SerializeField]
    private Image bar_fill;
    [SerializeField]
    private Sprite pb_clean;
    [SerializeField]
    private Sprite pb_postit;

    public TextMeshProUGUI color1_txt;
    public TextMeshProUGUI color2_txt;
    public TextMeshProUGUI color3_txt;

    public TextMeshProUGUI title_color1_txt;
    public TextMeshProUGUI title_color2_txt;
    public TextMeshProUGUI title_color3_txt;

    public TMP_Dropdown color1_dd;
    public TMP_Dropdown color2_dd;
    public TMP_Dropdown color3_dd;

    
    private int count;
    public DateTime tiempo1, tiempo2;

    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;

    public bool _hasfinish_stoop;

    [SerializeField] TextMeshProUGUI timer_text;
    public float remaining_time;
    private int minutes;
    private int seconds;

    public bool next;
    public bool restart;
    private bool start;
    public bool time;

    public string actual_date;

    //initialize variable count
    public void Start()
    {
        count = 1;
        remaining_time = 6;

        next = false;
        restart = true;
        time = false;
    }

    public void canStart()
    {
        start = true;
        count = 1;
        remaining_time = 6;

        start = false;
        next = false;
        restart = true;

        tiempo1 = DateTime.Now;
        month = DateTime.Now.ToString("MM");
        day = DateTime.Now.ToString("dd");
        year = DateTime.Now.ToString("yyyy");
        hour = DateTime.Now.ToString("HH");
        _min = DateTime.Now.ToString("mm");
        actual_date = day + "_" + month + "_" + year + "__" + hour + "_" + _min;

        start = true;
        Update();
    }

    //checks if there are more tests to continue or not
    public void Update()
    {

        if (count > 10 && time == false)
        {
            title_color1_txt.gameObject.SetActive(false);
            title_color2_txt.gameObject.SetActive(false);
            title_color3_txt.gameObject.SetActive(false);
            color1_dd.gameObject.SetActive(false);
            color2_dd.gameObject.SetActive(false);
            color3_dd.gameObject.SetActive(false);
            timer_text.gameObject.SetActive(false);
            _background.sprite = pb_clean;
            finish_btn.gameObject.SetActive(true);
            saveTimeResults();
            time = true;
        }
        else if (count <= 10 && start == true)
        {
            if ((color1_dd.value == 0 && color2_dd.value == 0 && color3_dd.value == 0) && restart == true)
            {
                title_color1_txt.gameObject.SetActive(true);
                title_color2_txt.gameObject.SetActive(true);
                title_color3_txt.gameObject.SetActive(true);

                remaining_time = Math.Abs(remaining_time);
                float timer = Math.Abs(Time.deltaTime);
                remaining_time -= timer;

                minutes = Mathf.FloorToInt(remaining_time / 60);
                seconds = Mathf.FloorToInt(remaining_time % 60);
                minutes = Math.Abs(minutes);
                seconds = Math.Abs(seconds);
                timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (minutes == 0 && seconds == 0)
                {
                    restart = false;
                    title_color1_txt.gameObject.SetActive(false);
                    title_color2_txt.gameObject.SetActive(false);
                    title_color3_txt.gameObject.SetActive(false);
                    color1_dd.gameObject.SetActive(true);
                    color2_dd.gameObject.SetActive(true);
                    color3_dd.gameObject.SetActive(true);
                    selectColors();
                    next = true;


                }
            }

            if ((color1_dd.value != 0 && color2_dd.value != 0 && color3_dd.value != 0) && next == true)
            {
                saveTestsResults();
                nextTest();
                next = false;

            }
        }

    }



    //Method for edit labels with color selectec in each dropdown
    public void selectColors()
    {
        color1_dd.onValueChanged.AddListener(delegate
        {
            if (color1_dd.value == 1)
            {
                color1_txt.text = "ROJO";
            } else if (color1_dd.value == 2)
            {
                color1_txt.text = "NARANJA";
            }
            else if (color1_dd.value == 3)
            {
                color1_txt.text = "AMARILLO";
            } else if (color1_dd.value == 4)
            {
                color1_txt.text = "VERDE";
            } else if (color1_dd.value == 5)
            {
                color1_txt.text = "AZUL";
            } else if (color1_dd.value == 6)
            {
                color1_txt.text = "MORADO";
            }
        });

        color2_dd.onValueChanged.AddListener(delegate
        {
            if (color2_dd.value == 1)
            {
                color2_txt.text = "ROJO";
            }
            else if (color2_dd.value == 2)
            {
                color2_txt.text = "NARANJA";
            }
            else if (color2_dd.value == 3)
            {
                color2_txt.text = "AMARILLO";
            }
            else if (color2_dd.value == 4)
            {
                color2_txt.text = "VERDE";
            }
            else if (color2_dd.value == 5)
            {
                color2_txt.text = "AZUL";
            }
            else if (color2_dd.value == 6)
            {
                color2_txt.text = "MORADO";
            }
        });

        color3_dd.onValueChanged.AddListener(delegate
        {
            if (color3_dd.value == 1)
            {
                color3_txt.text = "ROJO";
            }
            else if (color3_dd.value == 2)
            {
                color3_txt.text = "NARANJA";
            }
            else if (color3_dd.value == 3)
            {
                color3_txt.text = "AMARILLO";
            }
            else if (color3_dd.value == 4)
            {
                color3_txt.text = "VERDE";
            }
            else if (color3_dd.value == 5)
            {
                color3_txt.text = "AZUL";
            }
            else if (color3_dd.value == 6)
            {
                color3_txt.text = "MORADO";
            }
        });        
    }



    //Method for finish test
    public void finishStroop()
    {
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if(show != null)
        {
            show.show_weapon_card();
        }
        //_hasfinish_stoop = true;

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.weaponCollected();
        }

        Raycast raycast = GameObject.Find("pinboard").GetComponent<Raycast>();
        if (raycast != null)
        {
            raycast.canMove = false;
        }

        _canvasStroop.SetActive(false);
    }


    //Method for restore default values in dropdown and labels
    public void defaultValues()
    {
        color1_dd.gameObject.SetActive(false);
        color2_dd.gameObject.SetActive(false);
        color3_dd.gameObject.SetActive(false);   
        color1_txt.text = " ";
        color2_txt.text = " ";
        color3_txt.text = " ";
        title_color1_txt.gameObject.SetActive(true);
        title_color2_txt.gameObject.SetActive(true);
        title_color3_txt.gameObject.SetActive(true);
        //cambiar el fondo a con postits
        _background.sprite = pb_postit;
        color1_dd.value = 0; color2_dd.value = 0; color3_dd.value = 0;
        timer_text.gameObject.SetActive(true);
        remaining_time = 6;
    }


    public void saveTimeResults()
    {
        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Time_" + actual_date + ".txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";

        File.AppendAllLines(path, new String[] { text });
    }

    //Method for saving test results in .txt file
    public void saveTestsResults()
    {

        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results_" + actual_date + ".txt";
        string text = color1_txt.text + ", " + color2_txt.text + ", " + color3_txt.text;
        File.AppendAllLines(path, new String[] { text });
        //nextTest();
    }


    public void UpdateProgress()
    {
        float amount = (float)count / 10;
        bar_fill.fillAmount = amount;
    }


    //method that defines all tests labels and colors
    public void testOptions()
    {
        Color red = Color.HSVToRGB(0 / 360f, 100 / 100f, 100 / 100f);
        Color orange = Color.HSVToRGB(32 / 360f, 100 / 100f, 100 / 100f);
        Color yellow = Color.HSVToRGB(52 / 360f, 100 / 100f, 100 / 100f);
        Color green = Color.HSVToRGB(108 / 360f, 100 / 100f, 100 / 100f);
        Color blue = Color.HSVToRGB(215 / 360f, 100 / 100f, 100 / 100f);
        Color purple = Color.HSVToRGB(279 / 360f, 100 / 100f, 100 / 100f);

        if (count == 1)
        {
            
            title_color1_txt.text = "AZUL"; title_color1_txt.color = orange;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = blue;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = red;
        } else if (count == 2)
        {
            title_color1_txt.text = "MORADO"; title_color1_txt.color = yellow;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = blue;
            title_color3_txt.text = "NARANJA"; title_color3_txt.color = green;
        } else if (count == 3)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = blue;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = orange;
            title_color3_txt.text = "ROJO"; title_color3_txt.color = purple;
        } else if (count == 4)
        {
            title_color1_txt.text = "AMARILLO"; title_color1_txt.color = red;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = purple;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = yellow;
        } else if (count == 5)
        {
            title_color1_txt.text = "NARANJA"; title_color1_txt.color = yellow;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = green;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = blue;
        } else if (count == 6)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = green;
            title_color2_txt.text = "MORADO"; title_color2_txt.color = green;
            title_color3_txt.text = "VERDE"; title_color3_txt.color = orange;
        } else if (count == 7)
        {
            title_color1_txt.text = "ROJO"; title_color1_txt.color = orange;
            title_color2_txt.text = "NARANJA"; title_color2_txt.color = purple;
            title_color3_txt.text = "AZUL"; title_color3_txt.color = red;
        } else if (count == 8)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = purple;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = yellow;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = green;
        } else if (count == 9)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = purple;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = orange;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = red;

        } else if (count == 10)
        {
            title_color1_txt.text = "NARANJA"; title_color1_txt.color = red;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = blue;
            title_color3_txt.text = "NARANJA"; title_color3_txt.color = yellow;

        }
    }


    
    //method to change test
    public void nextTest()
    {
        UpdateProgress();
        count = count + 1;
        defaultValues();
        testOptions();
        restart = true;
    }

}
